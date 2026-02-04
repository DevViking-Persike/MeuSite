# ADR 0001: UI Blazor Compartilhada entre MAUI e Web

## Status
Aceito

## Contexto
A solução precisa compartilhar a interface de usuário entre um app .NET MAUI Hybrid e uma aplicação Blazor Web. Manter duas implementações de UI separadas geraria duplicação e divergência visual.

## Decisão
Criar uma Razor Class Library (MeuSite.Ui) que contém todos os componentes Blazor reutilizáveis. Tanto o projeto MAUI (via BlazorWebView) quanto o projeto Web (via Blazor Server) referenciam essa RCL.

## Alternativas Consideradas
1. **Duplicar componentes em cada projeto**: Descartado por violação de DRY e custo de manutenção.
2. **Usar o projeto Shared do template como RCL**: Descartado porque o projeto Shared foi reservado para contratos/modelos, mantendo separação de responsabilidades.
3. **Web Components (custom elements)**: Descartado pela complexidade de integração e perda de tipagem forte do C#/Blazor.

## Consequências
- **Positivo**: Uma única fonte de verdade para a UI. Componentes testáveis e reutilizáveis.
- **Positivo**: Ambos targets (MAUI/Web) ficam visualmente idênticos.
- **Negativo**: Assets estáticos da RCL são servidos via `_content/MeuSite.Ui/`, exigindo atenção nos caminhos.
- **Negativo**: CSS isolation gera arquivo `MeuSite.Ui.bundle.scp.css` que precisa ser referenciado.
