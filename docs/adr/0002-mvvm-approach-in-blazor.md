# ADR 0002: Abordagem MVVM em Blazor

## Status
Aceito

## Contexto
Precisamos separar a lógica de apresentação do markup Razor. Blazor não possui um padrão MVVM nativo como WPF/MAUI, mas podemos adaptar o conceito.

## Decisão
Implementar MVVM da seguinte forma:
- **View**: Páginas e componentes Razor (.razor files). Responsáveis apenas por renderização e binding.
- **ViewModel**: Classes C# no projeto MeuSite.Ui/ViewModels. Contêm estado (propriedades), comandos (métodos) e lógica de transformação/formatação do ResumeModel.
- **Model**: Records/DTOs em MeuSite.Shared/Models.

A View consome o ViewModel via injeção de dependência (`@inject`). Existe 1 ViewModel por Page (`ResumePageViewModel`) e ViewModels menores para Organisms quando necessário (`SkillsViewModel`).

ViewModels são registrados no container DI em cada host (MAUI e Web).

## Alternativas Consideradas
1. **Code-behind (.razor.cs)**: Descartado porque mistura ciclo de vida do componente com lógica de negócio. Dificuldade de teste unitário.
2. **Apenas Services**: Descartado porque não provê estado formatado para a View; resultaria em lógica de transformação espalhada nos .razor.
3. **Flux/Redux (Fluxor)**: Descartado por over-engineering para uma aplicação de portfólio.

## Consequências
- **Positivo**: ViewModels são testáveis unitariamente sem dependência de Blazor.
- **Positivo**: .razor files ficam limpos, apenas com binding.
- **Positivo**: Padrão familiar para desenvolvedores .NET.
- **Negativo**: Requer registro manual no DI de cada host.
- **Negativo**: StateHasChanged() não é chamado automaticamente pelo ViewModel; a Page deve orquestrar o carregamento no OnInitializedAsync.
