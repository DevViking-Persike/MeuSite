#!/bin/bash
# =============================================================================
# all.sh - Roda Web em modo desenvolvimento com hot reload
# =============================================================================
source "$(dirname "$0")/_common.sh"

check_web_dir
load_env

cleanup() {
    log_warn "Encerrando serviços..."
    kill $WEB_PID 2>/dev/null
    wait $WEB_PID 2>/dev/null
    log_info "Serviços encerrados."
    exit 0
}

trap cleanup SIGINT SIGTERM

log_info "==================================="
log_info "  MeuSite - Modo Desenvolvimento"
log_info "==================================="

log_blue "Iniciando Web (Blazor Server)..."
cd "$WEB_DIR" && dotnet watch run --launch-profile http &
WEB_PID=$!

log_info ""
log_cyan "Web:  http://localhost:7007"
log_info ""
log_info "Pressione Ctrl+C para encerrar."

wait $WEB_PID
