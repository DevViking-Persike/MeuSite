# MeuSite

Site portfólio pessoal de Victor Persike, construído com **.NET 9 MAUI Blazor Hybrid + Blazor Server**. Uma única base de código compartilhada que roda na Web e como app nativo (Android, iOS, macOS).

## Arquitetura

```
MeuSite/
├── src/
│   ├── MeuSite.Shared      # Contratos, interfaces e DTOs (sem implementação)
│   ├── MeuSite.Ui           # Razor Class Library - componentes Blazor compartilhados
│   ├── MeuSite.Web          # Blazor Server (host web)
│   └── MeuSite.Maui         # MAUI Blazor Hybrid (app nativo)
├── tests/
│   └── MeuSite.Tests        # Testes unitários (xUnit)
├── docs/adr/                # Architecture Decision Records
├── scripts/                 # Scripts de automação
├── Dockerfile               # Build multi-stage para produção
├── docker-compose.yml       # Orquestração Docker
└── run.sh                   # Script principal de execução
```

## Padrões

- **Atomic Design** - Componentes organizados em Atoms, Molecules, Organisms, Templates e Pages
- **MVVM** - ViewModels injetados via DI nos componentes Razor
- **Separation of Concerns** - `MeuSite.Shared` contém apenas contratos; implementações concretas ficam em `Web` e `Maui`

## Stack

| Tecnologia | Uso |
|---|---|
| .NET 9 | Runtime e SDK |
| Blazor Server | Renderização web (InteractiveServer) |
| MAUI Blazor Hybrid | App nativo via BlazorWebView |
| Razor Class Library | Componentes UI compartilhados |
| xUnit | Testes unitários |
| Docker | Containerização |

## Pré-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Docker](https://www.docker.com/) (opcional, para rodar via container)

Para MAUI (opcional):
- Xcode (iOS/macOS)
- Android SDK (Android)

## Como rodar

### Via script

```bash
./run.sh web          # Inicia o servidor web (porta 7007)
./run.sh all          # Dev mode com hot reload
./run.sh build        # Compila os projetos
./run.sh test         # Executa testes
./run.sh clean        # Limpa artefatos de build
./run.sh              # Mostra todos os comandos disponíveis
```

### Via Docker

```bash
docker compose up --build
```

Acesse: http://localhost:7007

### Via dotnet CLI

```bash
dotnet run --project src/MeuSite.Web
```

## Comandos disponíveis (run.sh)

| Comando | Descrição |
|---|---|
| `web` | Servidor web na porta 7007 |
| `all` | Dev mode com hot reload |
| `build` | Compila Web e Tests |
| `test` | Executa testes unitários |
| `maui` | App no MacCatalyst |
| `ios` | App no iOS Simulator |
| `android` | App no Android |
| `emu-list` | Lista emuladores Android |
| `sim-list` | Lista simuladores iOS |
| `clean` | Limpa bin/obj |
| `restore` | Restaura pacotes NuGet |
| `status` | Status dos serviços |
| `stop` | Para processos dotnet |

## Testes

```bash
./run.sh test
# ou
dotnet test tests/MeuSite.Tests
```

## Docker

Build multi-stage com SDK para compilação e ASP.NET runtime para execução:

```bash
# Build e execução
docker compose up --build -d

# Parar
docker compose down
```

## Estrutura de componentes (Atomic Design)

```
MeuSite.Ui/Components/
├── Atoms/           # ProfilePhoto, SkillCircle, SectionTitle, DecorativeDots
├── Molecules/       # ContactItem, EducationEntryItem, ExperienceCard, SkillItem
├── Organisms/       # HeroSection, ContactSidebar, EducationSection, ExperienceSection, SkillsSection
├── Templates/       # ResumeLayout
└── Pages/           # ResumePage
```

## Licença

Projeto pessoal de Victor Persike.
