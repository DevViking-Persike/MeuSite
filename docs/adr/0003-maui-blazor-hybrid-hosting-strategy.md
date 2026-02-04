# ADR 0003: Estratégia de Hosting MAUI Blazor Hybrid

## Status
Aceito

## Contexto
O template `maui-blazor-web` gera uma solução com MAUI Blazor Hybrid e Blazor Web. Precisamos decidir como hospedar os componentes compartilhados em ambos os targets.

## Decisão
- **MAUI**: Usa `BlazorWebView` com `HostPage="wwwroot/index.html"`, carregando `Routes` da RCL (MeuSite.Ui).
- **Web**: Usa Blazor Server com `MapRazorComponents<App>()` e `AddAdditionalAssemblies()` apontando para a RCL.
- **Render Mode**: InteractiveServer para Web. MAUI roda tudo local (sem server).
- **Serviços concretos**: Cada host registra sua implementação de `IResumeDataProvider` no DI.

## Alternativas Consideradas
1. **Blazor WebAssembly para Web**: Descartado para simplificar; o portfólio não precisa de client-side rendering. Server simplifica o deploy.
2. **Auto render mode (Server + WASM)**: Descartado por complexidade desnecessária para o escopo.
3. **Serviço compartilhado com dados embarcados**: Descartado para manter a flexibilidade de fontes de dados diferentes por host.

## Consequências
- **Positivo**: Cada host pode ter sua própria fonte de dados (API, arquivo, hardcoded).
- **Positivo**: MAUI funciona offline (dados locais).
- **Positivo**: Web funciona com Blazor Server (deploy simples).
- **Negativo**: Duplicação do ResumeDataProvider em MAUI e Web (mitigado por refatoração futura para um pacote NuGet ou shared service).
