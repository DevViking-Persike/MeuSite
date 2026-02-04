#!/bin/bash
# =============================================================================
# maui.sh - Roda o projeto MAUI (Mac Catalyst / iOS)
# =============================================================================
source "$(dirname "$0")/_common.sh"

check_maui_dir

PLATFORM="${1:-mac}"

case "$PLATFORM" in
    mac|maccatalyst)
        log_info "Rodando MAUI no Mac Catalyst..."
        cd "$MAUI_DIR" && dotnet build -t:Run -f net9.0-maccatalyst
        ;;
    ios)
        log_info "Rodando MAUI no iOS Simulator..."
        cd "$MAUI_DIR" && dotnet build -t:Run -f net9.0-ios
        ;;
    *)
        log_error "Plataforma inválida: $PLATFORM"
        echo "Uso: $0 [mac|ios]"
        exit 1
        ;;
esac
