#!/bin/bash
# MeuSite - Script principal
# Uso: ./run.sh [comando]

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
SCRIPTS_DIR="$SCRIPT_DIR/scripts"

# Cores
BLUE='\033[0;34m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
NC='\033[0m'

show_help() {
    echo -e "${BLUE}MeuSite - Script de Execucao${NC}"
    echo ""
    echo "Uso: ./run.sh [comando]"
    echo ""
    echo -e "${GREEN}Principais:${NC}"
    echo "  all       - Web com hot reload (desenvolvimento)"
    echo "  web       - Web (porta 5000)"
    echo ""
    echo -e "${GREEN}MAUI:${NC}"
    echo "  maui      - App no MacCatalyst"
    echo "  ios       - App no iOS Simulator"
    echo "  android   - App no Android (inicia emulador)"
    echo ""
    echo -e "${GREEN}Android:${NC}"
    echo "  emu-list  - Lista emuladores"
    echo "  emu-start - Inicia emulador"
    echo "  emu-stop  - Para emulador"
    echo ""
    echo -e "${GREEN}iOS:${NC}"
    echo "  sim-list  - Lista simuladores"
    echo "  sim-start - Inicia simulador"
    echo "  sim-stop  - Para simuladores"
    echo ""
    echo -e "${GREEN}Build:${NC}"
    echo "  build         - Compila projetos"
    echo "  build-android - Gera AAB/APK para Google Play"
    echo ""
    echo -e "${GREEN}Testes:${NC}"
    echo "  test      - Testes unitarios + bUnit"
    echo "  test-e2e  - Testes E2E (Playwright)"
    echo "  test-all  - Todos os testes"
    echo ""
    echo -e "${GREEN}Manutencao:${NC}"
    echo "  restore   - Restaura dependencias"
    echo "  clean     - Limpa artefatos"
    echo "  status    - Status dos servicos"
    echo "  stop      - Para processos dotnet"
    echo ""
    echo -e "${YELLOW}Porta:${NC}"
    echo "  Web: http://localhost:7007"
}

case "${1:-help}" in
    # Principais
    all|dev)
        "$SCRIPTS_DIR/all.sh"
        ;;
    web)
        "$SCRIPTS_DIR/web.sh"
        ;;

    # MAUI
    maui|mac)
        "$SCRIPTS_DIR/maui.sh" mac
        ;;

    # iOS
    ios)
        "$SCRIPTS_DIR/ios.sh" run
        ;;
    sim-list|simulators)
        "$SCRIPTS_DIR/ios.sh" list
        ;;
    sim-start|sim)
        "$SCRIPTS_DIR/ios.sh" start
        ;;
    sim-stop)
        "$SCRIPTS_DIR/ios.sh" stop
        ;;

    # Android
    android)
        "$SCRIPTS_DIR/android.sh" run
        ;;
    emu-list|emulators)
        "$SCRIPTS_DIR/android.sh" list
        ;;
    emu-start|emu)
        "$SCRIPTS_DIR/android.sh" start
        ;;
    emu-stop)
        "$SCRIPTS_DIR/android.sh" stop
        ;;

    # Build
    build)
        "$SCRIPTS_DIR/build.sh"
        ;;
    build-android|aab|apk)
        "$SCRIPTS_DIR/build-android.sh" "${@:2}"
        ;;

    # Manutencao
    restore)
        "$SCRIPTS_DIR/utils.sh" restore
        ;;
    clean)
        "$SCRIPTS_DIR/utils.sh" clean
        ;;
    test)
        "$SCRIPTS_DIR/utils.sh" test
        ;;
    test-e2e|e2e)
        "$SCRIPTS_DIR/utils.sh" test-e2e
        ;;
    test-all)
        "$SCRIPTS_DIR/utils.sh" test-all
        ;;
    status)
        "$SCRIPTS_DIR/utils.sh" status
        ;;
    stop)
        "$SCRIPTS_DIR/utils.sh" stop
        ;;

    # Help
    help|-h|--help|*)
        show_help
        ;;
esac
