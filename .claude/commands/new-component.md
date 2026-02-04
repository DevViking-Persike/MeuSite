Crie um novo componente Blazor no projeto MeuSite seguindo o padrão Atomic Design.

O usuário vai informar: $ARGUMENTS

Extraia do argumento:
- **Nome do componente** (ex: "SocialLink", "ProjectCard")
- **Nível Atomic Design** (atom, molecule, organism) - se não informado, pergunte

## Regras

1. O componente deve ser criado em `src/MeuSite.Ui/Components/{Nivel}/` onde Nivel é:
   - `Atoms/` - elementos simples e independentes (botão, ícone, badge, título)
   - `Molecules/` - combinação de 2+ átomos (card item, contact entry)
   - `Organisms/` - seções completas compostas por moléculas (HeroSection, SkillsSection)

2. Crie dois arquivos:
   - `{Nome}.razor` - markup do componente com `@code` block ou `[Parameter]` properties
   - `{Nome}.razor.css` - CSS isolado (scoped) seguindo o padrão visual do site:
     - Fundo escuro: `#2b2b2b`
     - Texto principal: `#ffffff`
     - Texto secundário: `#cccccc`
     - Cor destaque/accent: `#e8b827` (dourado)
     - Font monospace para subtítulos

3. Use parâmetros `[Parameter]` para dados dinâmicos, nunca hardcode texto

4. Se o componente precisar de dados do ViewModel, injete com `@inject`

5. Adicione responsividade com `@@media (max-width: 768px)` quando apropriado

6. Após criar, mostre como usar o componente em outro arquivo Razor

## Exemplo de estrutura

```
// Atoms/Badge.razor
<span class="badge">@Text</span>
@code {
    [Parameter] public string Text { get; set; } = "";
}
```
