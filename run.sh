#!/bin/bash
# MeuSite — SvelteKit
# Uso: ./run.sh [comando]

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
cd "$SCRIPT_DIR"

BLUE='\033[0;34m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
NC='\033[0m'

show_help() {
    echo -e "${BLUE}MeuSite — SvelteKit${NC}"
    echo ""
    echo "Uso: ./run.sh [comando]"
    echo ""
    echo -e "${GREEN}Dev:${NC}"
    echo "  install      - pnpm install"
    echo "  dev          - vite dev (http://localhost:5173)"
    echo "  check        - svelte-check"
    echo ""
    echo -e "${GREEN}Build / Prod:${NC}"
    echo "  build        - vite build (gera build/)"
    echo "  preview      - vite preview"
    echo "  start        - node build/index.js"
    echo ""
    echo -e "${GREEN}Docker:${NC}"
    echo "  docker-build - docker compose build"
    echo "  docker-up    - docker compose up -d"
    echo "  docker-down  - docker compose down"
    echo "  docker-logs  - docker compose logs -f web"
    echo ""
    echo -e "${GREEN}Testes:${NC}"
    echo "  test         - pnpm test"
    echo ""
    echo -e "${GREEN}Limpeza:${NC}"
    echo "  clean        - remove node_modules/.svelte-kit/build"
    echo ""
    echo -e "${YELLOW}Porta dev:${NC} http://localhost:5173"
}

case "${1:-help}" in
    install|i)
        pnpm install
        ;;
    dev|all)
        pnpm dev
        ;;
    check)
        pnpm check
        ;;
    build)
        pnpm build
        ;;
    preview)
        pnpm preview
        ;;
    start|prod)
        node build/index.js
        ;;
    docker-build)
        docker compose build
        ;;
    docker-up|up)
        docker compose up -d
        ;;
    docker-down|down)
        docker compose down
        ;;
    docker-logs|logs)
        docker compose logs -f web
        ;;
    test)
        pnpm test
        ;;
    clean)
        rm -rf node_modules .svelte-kit build
        echo "Limpeza concluída."
        ;;
    help|-h|--help|*)
        show_help
        ;;
esac
