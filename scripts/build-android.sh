#!/bin/bash
# =============================================================================
# build-android.sh - Build Android para publicação (AAB/APK)
# =============================================================================
source "$(dirname "$0")/_common.sh"

check_maui_dir

KEYSTORE_DIR="$MAUI_DIR/Platforms/Android/keystore"
KEYSTORE_FILE="$KEYSTORE_DIR/meusite.jks"
KEYSTORE_ALIAS="meusite"
KEYSTORE_PASS="meusite"
OUTPUT_DIR="$PROJECT_DIR/artifacts/android"

show_help() {
    echo "Uso: $0 [comando]"
    echo ""
    echo "Comandos:"
    echo "  aab              Gerar AAB Release (padrão)"
    echo "  apk              Gerar APK Release"
    echo "  debug            Gerar AAB Debug"
    echo "  create-keystore  Criar novo keystore"
    echo "  info             Mostrar info do keystore"
    echo "  help             Mostrar esta ajuda"
}

check_keystore() {
    if [ ! -f "$KEYSTORE_FILE" ]; then
        log_error "Keystore não encontrado em: $KEYSTORE_FILE"
        log_warn "Execute: $0 create-keystore"
        exit 1
    fi
}

show_keystore_info() {
    check_keystore
    log_info "Informações do keystore:"
    keytool -list -v -keystore "$KEYSTORE_FILE" -storepass "$KEYSTORE_PASS" -alias "$KEYSTORE_ALIAS" 2>/dev/null
}

create_keystore() {
    mkdir -p "$KEYSTORE_DIR"

    if [ -f "$KEYSTORE_FILE" ]; then
        log_warn "Keystore já existe: $KEYSTORE_FILE"
        read -p "Sobrescrever? (s/N) " RESP
        if [ "$RESP" != "s" ] && [ "$RESP" != "S" ]; then
            exit 0
        fi
    fi

    log_info "Criando keystore..."
    keytool -genkeypair \
        -v \
        -keystore "$KEYSTORE_FILE" \
        -alias "$KEYSTORE_ALIAS" \
        -keyalg RSA \
        -keysize 2048 \
        -validity 10000 \
        -storepass "$KEYSTORE_PASS" \
        -keypass "$KEYSTORE_PASS" \
        -dname "CN=Victor Persike, OU=Dev, O=MeuSite, L=Sao Paulo, ST=SP, C=BR"

    if [ $? -eq 0 ]; then
        log_info "Keystore criado com sucesso: $KEYSTORE_FILE"
    else
        log_error "Falha ao criar keystore."
        exit 1
    fi
}

build_android() {
    local FORMAT="${1:-aab}"
    local CONFIG="${2:-Release}"

    mkdir -p "$OUTPUT_DIR"

    local PACKAGE_FORMAT="aab"
    if [ "$FORMAT" = "apk" ]; then
        PACKAGE_FORMAT="apk"
    fi

    log_info "Build Android ($CONFIG) - Formato: $PACKAGE_FORMAT"

    local BUILD_ARGS=(
        -f net9.0-android
        -c "$CONFIG"
        -p:AndroidPackageFormat=$PACKAGE_FORMAT
    )

    if [ "$CONFIG" = "Release" ]; then
        check_keystore
        BUILD_ARGS+=(
            -p:AndroidKeyStore=true
            -p:AndroidSigningKeyStore="$KEYSTORE_FILE"
            -p:AndroidSigningKeyAlias="$KEYSTORE_ALIAS"
            -p:AndroidSigningStorePass="$KEYSTORE_PASS"
            -p:AndroidSigningKeyPass="$KEYSTORE_PASS"
            -p:Debuggable=false
            -p:EmbedAssembliesIntoApk=true
            -p:DebugSymbols=true
            -p:DebugType=portable
            -p:AndroidIncludeDebugSymbols=true
        )
    fi

    cd "$MAUI_DIR"
    dotnet publish "${BUILD_ARGS[@]}"

    if [ $? -eq 0 ]; then
        log_info "Build concluído!"

        local ARTIFACT=$(find "$MAUI_DIR/bin/$CONFIG/net9.0-android" -name "*.$PACKAGE_FORMAT" -type f 2>/dev/null | head -1)
        if [ -n "$ARTIFACT" ]; then
            cp "$ARTIFACT" "$OUTPUT_DIR/"
            log_info "Artefato copiado para: $OUTPUT_DIR/$(basename "$ARTIFACT")"
        fi

        generate_symbols_package "$CONFIG"
    else
        log_error "Falha no build Android."
        exit 1
    fi
}

generate_symbols_package() {
    local CONFIG="${1:-Release}"
    local SYMBOLS_DIR="$MAUI_DIR/bin/$CONFIG/net9.0-android"
    local SYMBOLS_ZIP="$OUTPUT_DIR/meusite-symbols-$(date +%Y%m%d).zip"

    local SO_FILES=$(find "$SYMBOLS_DIR" -name "*.so" -type f 2>/dev/null)
    if [ -n "$SO_FILES" ]; then
        log_info "Gerando pacote de símbolos..."
        cd "$SYMBOLS_DIR"
        find . -name "*.so" | zip -@ "$SYMBOLS_ZIP" 2>/dev/null
        log_info "Símbolos: $SYMBOLS_ZIP"
    fi
}

# Comandos
COMMAND="${1:-aab}"

case "$COMMAND" in
    aab)              build_android "aab" "Release" ;;
    apk)              build_android "apk" "Release" ;;
    debug)            build_android "aab" "Debug" ;;
    create-keystore)  create_keystore ;;
    info)             show_keystore_info ;;
    help)             show_help ;;
    *)
        log_error "Comando desconhecido: $COMMAND"
        show_help
        exit 1
        ;;
esac
