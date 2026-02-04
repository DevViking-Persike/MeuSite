#!/bin/bash
# =============================================================================
# _common.sh - Variáveis e funções compartilhadas entre todos os scripts
# =============================================================================

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PROJECT_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"
SRC_DIR="$PROJECT_DIR/src"
WEB_DIR="$SRC_DIR/MeuSite.Web"
MAUI_DIR="$SRC_DIR/MeuSite.Maui"
SHARED_DIR="$SRC_DIR/MeuSite.Shared"
UI_DIR="$SRC_DIR/MeuSite.Ui"
TESTS_DIR="$PROJECT_DIR/tests/MeuSite.Tests"
E2E_DIR="$PROJECT_DIR/tests/MeuSite.E2E"
SLN_FILE="$PROJECT_DIR/MeuSite.sln"

PACKAGE_NAME="com.victorpersike.meusite"
BUNDLE_ID="com.victorpersike.meusite"

# Cores para output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
CYAN='\033[0;36m'
NC='\033[0m' # No Color

log_info()  { echo -e "${GREEN}[INFO]${NC} $1"; }
log_warn()  { echo -e "${YELLOW}[WARN]${NC} $1"; }
log_error() { echo -e "${RED}[ERRO]${NC} $1"; }
log_blue()  { echo -e "${BLUE}[INFO]${NC} $1"; }
log_cyan()  { echo -e "${CYAN}[INFO]${NC} $1"; }

check_web_dir() {
    if [ ! -d "$WEB_DIR" ]; then
        log_error "Diretório Web não encontrado: $WEB_DIR"
        exit 1
    fi
}

check_maui_dir() {
    if [ ! -d "$MAUI_DIR" ]; then
        log_error "Diretório MAUI não encontrado: $MAUI_DIR"
        exit 1
    fi
}

load_env() {
    if [ -f "$PROJECT_DIR/.env" ]; then
        export $(grep -v '^#' "$PROJECT_DIR/.env" | xargs)
        log_info "Variáveis de ambiente carregadas de .env"
    fi
}
