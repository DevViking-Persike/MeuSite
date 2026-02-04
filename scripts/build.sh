#!/bin/bash
# =============================================================================
# build.sh - Compila os projetos da solução
# =============================================================================
source "$(dirname "$0")/_common.sh"

log_info "Compilando solução MeuSite..."

cd "$PROJECT_DIR"

log_blue "Build: MeuSite.Shared + MeuSite.Ui + MeuSite.Web"
dotnet build "$WEB_DIR/MeuSite.Web.csproj"

if [ $? -eq 0 ]; then
    log_info "Build Web concluído com sucesso!"
else
    log_error "Falha no build Web."
    exit 1
fi

log_blue "Build: Testes"
dotnet build "$TESTS_DIR/MeuSite.Tests.csproj"

if [ $? -eq 0 ]; then
    log_info "Build completo com sucesso!"
else
    log_warn "Build dos testes falhou."
fi
