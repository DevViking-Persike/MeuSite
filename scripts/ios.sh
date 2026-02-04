#!/bin/bash
# =============================================================================
# ios.sh - Gerencia simulador iOS e executa o app MAUI
# =============================================================================
source "$(dirname "$0")/_common.sh"

check_maui_dir

list_simulators() {
    log_info "Simuladores iPhone disponíveis:"
    xcrun simctl list devices available | grep -i "iphone"
    echo ""
    log_info "Simuladores iPad disponíveis:"
    xcrun simctl list devices available | grep -i "ipad"
    echo ""
    log_info "Simuladores em execução:"
    xcrun simctl list devices booted
}

get_booted_simulator() {
    xcrun simctl list devices booted | grep -oE '[A-F0-9-]{36}' | head -1
}

get_available_iphone() {
    for VERSION in 18 17 16 15; do
        local DEVICE=$(xcrun simctl list devices available | grep -i "iphone" | grep "iOS $VERSION" | grep -oE '[A-F0-9-]{36}' | head -1)
        if [ -n "$DEVICE" ]; then
            echo "$DEVICE"
            return 0
        fi
    done

    xcrun simctl list devices available | grep -i "iphone" | grep -oE '[A-F0-9-]{36}' | head -1
}

wait_for_simulator_ready() {
    local DEVICE_ID="$1"
    log_info "Aguardando simulador ficar pronto..."
    xcrun simctl bootstatus "$DEVICE_ID" -b 2>/dev/null
}

start_simulator() {
    local DEVICE_ID="${1:-}"

    if [ -z "$DEVICE_ID" ]; then
        DEVICE_ID=$(get_available_iphone)
    fi

    if [ -z "$DEVICE_ID" ]; then
        log_error "Nenhum simulador iPhone disponível."
        exit 1
    fi

    local DEVICE_NAME=$(xcrun simctl list devices | grep "$DEVICE_ID" | sed 's/.*\(.*\) (.*/\1/' | head -1)
    log_info "Iniciando simulador: $DEVICE_NAME ($DEVICE_ID)"

    xcrun simctl boot "$DEVICE_ID" 2>/dev/null
    open -a Simulator

    local TIMEOUT=60
    local COUNT=0
    while [ $COUNT -lt $TIMEOUT ]; do
        local BOOTED=$(get_booted_simulator)
        if [ -n "$BOOTED" ]; then
            wait_for_simulator_ready "$BOOTED"
            log_info "Simulador pronto!"
            return 0
        fi
        sleep 2
        COUNT=$((COUNT + 2))
        echo -ne "\r  Aguardando boot... ${COUNT}s / ${TIMEOUT}s"
    done
    echo ""
    log_error "Timeout esperando o simulador."
    exit 1
}

stop_simulator() {
    log_info "Parando simuladores..."
    xcrun simctl shutdown all 2>/dev/null
    log_info "Simuladores encerrados."
}

run_app() {
    local BOOTED_ID=$(get_booted_simulator)

    if [ -z "$BOOTED_ID" ]; then
        log_warn "Nenhum simulador em execução. Iniciando..."
        start_simulator
        BOOTED_ID=$(get_booted_simulator)
    fi

    if [ -z "$BOOTED_ID" ]; then
        log_error "Não foi possível obter simulador."
        exit 1
    fi

    log_info "Compilando e executando MeuSite no iOS Simulator..."
    cd "$MAUI_DIR" && dotnet build -t:Run -f net9.0-ios -p:_DeviceName=:v2:udid=$BOOTED_ID

    if [ $? -eq 0 ]; then
        log_info "App executando no simulador."
    else
        log_error "Falha no build iOS."
        exit 1
    fi
}

# Comandos
COMMAND="${1:-run}"

case "$COMMAND" in
    run)    run_app ;;
    list)   list_simulators ;;
    start)  start_simulator "$2" ;;
    stop)   stop_simulator ;;
    *)
        echo "Uso: $0 [run|list|start|stop]"
        echo "  run          - Compila e executa o app (padrão)"
        echo "  list         - Lista simuladores disponíveis"
        echo "  start [ID]   - Inicia simulador específico"
        echo "  stop         - Para todos os simuladores"
        exit 1
        ;;
esac
