Crie uma nova página Blazor no projeto MeuSite seguindo a arquitetura existente.

O usuário vai informar: $ARGUMENTS

Extraia do argumento:
- **Nome da página** (ex: "Projects", "Blog", "Contact")
- **Rota** (ex: "/projects") - se não informada, derive do nome

## Passos obrigatórios

### 1. Model (se necessário)
- Crie o model em `src/MeuSite.Shared/Models/`
- Use `record` para DTOs imutáveis
- Exemplo: `public record ProjectItem(string Title, string Description, string Url);`

### 2. Interface do DataProvider (se necessário)
- Adicione método na interface existente `src/MeuSite.Shared/Interfaces/IResumeDataProvider.cs`
- Ou crie uma nova interface se for um domínio diferente

### 3. ViewModel
- Crie em `src/MeuSite.Ui/ViewModels/{Nome}PageViewModel.cs`
- Injete o DataProvider via construtor
- Exponha propriedades formatadas para a View (padrão MVVM)
- Inclua método `LoadAsync()` para carregar dados

### 4. Page (Template level)
- Crie em `src/MeuSite.Ui/Components/Pages/{Nome}Page.razor`
- Use `@page "/{rota}"`
- Injete o ViewModel com `@inject`
- Chame `ViewModel.LoadAsync()` no `OnInitializedAsync`
- Compose usando Organisms existentes ou novos

### 5. Organisms/Sections
- Crie as seções da página em `src/MeuSite.Ui/Components/Organisms/`
- Cada seção visual distinta deve ser um Organism separado

### 6. Registrar serviços
- Registre o ViewModel como `AddScoped` em:
  - `src/MeuSite.Web/Program.cs`
  - `src/MeuSite.Maui/MauiProgram.cs`

### 7. Implementar DataProvider
- Adicione dados mockados em `src/MeuSite.Web/Services/WebResumeDataProvider.cs`
- Adicione dados mockados em `src/MeuSite.Maui/Services/MauiResumeDataProvider.cs`

### 8. Navegação (se aplicável)
- Adicione link de navegação para a nova página onde apropriado

## Padrão visual
- Fundo: `#2b2b2b`, Texto: `#ffffff`, Accent: `#e8b827`
- Max-width: `1200px` centralizado
- Responsivo com breakpoint `768px`

## Após criar
- Liste todos os arquivos criados/modificados
- Mostre como acessar a página
- Pergunte se deseja rodar para testar
