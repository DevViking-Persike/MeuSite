# MeuSite - Portfolio Victor Persike

Solução .NET 9 com MAUI Blazor Hybrid + Blazor Web, compartilhando UI via Razor Class Library.

## Arquitetura

```
MeuSite/
├── claude.md                    # Este arquivo
├── MeuSite.sln                 # Solução principal
├── docs/
│   └── adr/                    # Architecture Decision Records
├── src/
│   ├── MeuSite.Shared/         # Contratos, interfaces, models/DTOs
│   ├── MeuSite.Ui/             # RCL: Componentes Blazor (Atomic Design) + ViewModels
│   ├── MeuSite.Maui/           # Host MAUI Blazor Hybrid
│   └── MeuSite.Web/            # Host Blazor Server
└── tests/
    └── MeuSite.Tests/          # Testes unitários (xUnit)
```

## Padrões Adotados

- **Atomic Design**: Atoms → Molecules → Organisms → Templates → Pages
- **MVVM**: ViewModels injetados via DI nos componentes Razor
- **Shared Contracts**: MeuSite.Shared contém apenas interfaces e DTOs
- **Implementações concretas**: Cada host (MAUI/Web) implementa IResumeDataProvider

## Como Rodar

### Web (Blazor Server)
```bash
cd src/MeuSite.Web
dotnet run
# Acesse https://localhost:5001 (ou a porta indicada no terminal)
```

### MAUI (Mac Catalyst)
```bash
dotnet build src/MeuSite.Maui -f net9.0-maccatalyst
dotnet build src/MeuSite.Maui -f net9.0-maccatalyst -t:Run
```

### MAUI (Android)
```bash
dotnet build src/MeuSite.Maui -f net9.0-android
```

## Build da Solução Completa

```bash
# Build apenas Web + Shared + Ui + Tests (recomendado no dev diário)
dotnet build MeuSite.sln -p:TargetFramework=net9.0 --no-incremental

# Build Web isolado
dotnet build src/MeuSite.Web

# Build MAUI (requer workload maui)
dotnet build src/MeuSite.Maui -f net9.0-maccatalyst
```

## Testes

```bash
dotnet test tests/MeuSite.Tests
```

## Publicar Web

```bash
dotnet publish src/MeuSite.Web -c Release -o ./publish
```

## Decisões Arquiteturais

Veja `/docs/adr/` para todas as ADRs:
- 0001: UI compartilhada entre MAUI e Web
- 0002: Abordagem MVVM em Blazor
- 0003: Estratégia de hosting MAUI Blazor Hybrid
- 0004: Atomic Design para componentes

## Stack

- .NET 9
- Blazor Server (Web)
- .NET MAUI Blazor Hybrid
- Razor Class Library
- xUnit (testes)
- CSS Isolation (scoped CSS)
