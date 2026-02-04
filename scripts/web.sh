#!/bin/bash
# =============================================================================
# web.sh - Roda o projeto Web (Blazor Server)
# =============================================================================
source "$(dirname "$0")/_common.sh"

check_web_dir
load_env

log_info "Iniciando MeuSite.Web..."
log_cyan "URL: http://localhost:7007"
cd "$WEB_DIR" && dotnet run --launch-profile http
