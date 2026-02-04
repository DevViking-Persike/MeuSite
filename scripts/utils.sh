#!/bin/bash
# =============================================================================
# utils.sh - Utilitários de manutenção do projeto
# =============================================================================
source "$(dirname "$0")/_common.sh"

show_status() {
    log_info "Status dos serviços:"

    if lsof -i :7007 -sTCP:LISTEN &>/dev/null; then
        log_info "  Web (5000): ${GREEN}RODANDO${NC}"
    else
        log_warn "  Web (5000): PARADO"
    fi
}

stop_all() {
    log_info "Parando processos dotnet..."
    pkill -f "dotnet run" 2>/dev/null
    pkill -f "dotnet watch" 2>/dev/null
    sleep 1
    log_info "Processos encerrados."
}

clean_projects() {
    log_info "Limpando artefatos de build..."

    cd "$PROJECT_DIR"
    find . -type d \( -name "bin" -o -name "obj" \) -not -path "*/node_modules/*" -exec rm -rf {} + 2>/dev/null

    if [ -d "$PROJECT_DIR/artifacts" ]; then
        rm -rf "$PROJECT_DIR/artifacts"
        log_info "Pasta artifacts removida."
    fi

    log_info "Limpeza concluída."
}

restore_packages() {
    log_info "Restaurando pacotes NuGet..."
    cd "$PROJECT_DIR" && dotnet restore "$SLN_FILE"

    if [ $? -eq 0 ]; then
        log_info "Pacotes restaurados com sucesso."
    else
        log_error "Falha na restauração de pacotes."
        exit 1
    fi
}

test_projects() {
    log_info "Executando testes..."
    cd "$PROJECT_DIR" && dotnet test "$TESTS_DIR/MeuSite.Tests.csproj"

    if [ $? -eq 0 ]; then
        log_info "Todos os testes passaram!"
    else
        log_error "Alguns testes falharam."
        exit 1
    fi
}

# Comandos
COMMAND="${1:-status}"

case "$COMMAND" in
    status)   show_status ;;
    stop)     stop_all ;;
    clean)    clean_projects ;;
    restore)  restore_packages ;;
    test)     test_projects ;;
    *)
        echo "Uso: $0 [status|stop|clean|restore|test]"
        echo "  status   - Mostra status dos serviços (padrão)"
        echo "  stop     - Para todos os processos dotnet"
        echo "  clean    - Remove pastas bin/obj"
        echo "  restore  - Restaura pacotes NuGet"
        echo "  test     - Executa testes unitários"
        exit 1
        ;;
esac
