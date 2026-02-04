#!/bin/bash
# =============================================================================
# android.sh - Gerencia emulador Android e executa o app MAUI
# =============================================================================
source "$(dirname "$0")/_common.sh"

check_maui_dir

ANDROID_HOME="${ANDROID_HOME:-$HOME/Library/Android/sdk}"

get_emulator_cmd() {
    if [ -f "$ANDROID_HOME/emulator/emulator" ]; then
        echo "$ANDROID_HOME/emulator/emulator"
    elif command -v emulator &> /dev/null; then
        echo "emulator"
    else
        log_error "Emulador Android não encontrado. Verifique ANDROID_HOME."
        exit 1
    fi
}

list_emulators() {
    log_info "Emuladores disponíveis:"
    $(get_emulator_cmd) -list-avds 2>/dev/null

    log_info "Dispositivos conectados:"
    "$ANDROID_HOME/platform-tools/adb" devices 2>/dev/null
}

start_emulator() {
    local EMU_CMD=$(get_emulator_cmd)
    local AVD=$($(get_emulator_cmd) -list-avds 2>/dev/null | head -1)

    if [ -z "$AVD" ]; then
        log_error "Nenhum AVD encontrado. Crie um emulador no Android Studio."
        exit 1
    fi

    log_info "Iniciando emulador: $AVD"
    $EMU_CMD -avd "$AVD" -no-snapshot-load &

    local TIMEOUT=60
    local COUNT=0
    while [ $COUNT -lt $TIMEOUT ]; do
        if "$ANDROID_HOME/platform-tools/adb" shell getprop sys.boot_completed 2>/dev/null | grep -q "1"; then
            log_info "Emulador pronto!"
            return 0
        fi
        sleep 2
        COUNT=$((COUNT + 2))
        echo -ne "\r  Aguardando boot... ${COUNT}s / ${TIMEOUT}s"
    done
    echo ""
    log_error "Timeout esperando o emulador."
    exit 1
}

stop_emulator() {
    log_info "Parando emuladores..."
    "$ANDROID_HOME/platform-tools/adb" emu kill 2>/dev/null
    log_info "Emuladores encerrados."
}

run_app() {
    local DEVICE=$("$ANDROID_HOME/platform-tools/adb" devices | grep -w "device" | head -1 | awk '{print $1}')

    if [ -z "$DEVICE" ]; then
        log_warn "Nenhum dispositivo conectado. Iniciando emulador..."
        start_emulator
    fi

    log_info "Compilando e instalando MeuSite no Android..."
    cd "$MAUI_DIR" && dotnet build -t:Install -f net9.0-android -p:AndroidOnly=true

    if [ $? -eq 0 ]; then
        log_info "App instalado! Iniciando..."
        "$ANDROID_HOME/platform-tools/adb" shell monkey -p "$PACKAGE_NAME" -c android.intent.category.LAUNCHER 1 2>/dev/null
        log_info "App iniciado no dispositivo."
    else
        log_error "Falha no build Android."
        exit 1
    fi
}

# Comandos
COMMAND="${1:-run}"

case "$COMMAND" in
    run)    run_app ;;
    list)   list_emulators ;;
    start)  start_emulator ;;
    stop)   stop_emulator ;;
    *)
        echo "Uso: $0 [run|list|start|stop]"
        echo "  run   - Compila e executa o app (padrão)"
        echo "  list  - Lista emuladores e dispositivos"
        echo "  start - Inicia emulador sem executar o app"
        echo "  stop  - Para emuladores"
        exit 1
        ;;
esac
