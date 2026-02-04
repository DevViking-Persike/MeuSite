Implemente uma nova funcionalidade no projeto MeuSite.

O usuário vai informar: $ARGUMENTS

Extraia do argumento a descrição da feature desejada.

## Processo

### 1. Análise
- Entenda o que a feature precisa fazer
- Identifique quais camadas do projeto serão afetadas:
  - `MeuSite.Shared` - Novos models, interfaces, DTOs
  - `MeuSite.Ui` - Componentes, ViewModels, CSS
  - `MeuSite.Web` - Serviços, configuração do host web
  - `MeuSite.Maui` - Serviços, configuração do host nativo
  - `MeuSite.Tests` - Testes unitários

### 2. Planejamento
- Apresente ao usuário um plano com os arquivos que serão criados/modificados
- Aguarde aprovação antes de implementar

### 3. Implementação
Siga a ordem de dependência:
1. **Models/DTOs** em `MeuSite.Shared/Models/`
2. **Interfaces** em `MeuSite.Shared/Interfaces/`
3. **ViewModels** em `MeuSite.Ui/ViewModels/`
4. **Componentes** em `MeuSite.Ui/Components/` (Atomic Design)
5. **Serviços Web** em `MeuSite.Web/Services/`
6. **Serviços MAUI** em `MeuSite.Maui/Services/`
7. **Registro DI** em `Program.cs` / `MauiProgram.cs`
8. **Testes** em `MeuSite.Tests/`

### 4. Padrões a seguir
- **MVVM**: Dados via ViewModel, nunca direto no componente
- **DI**: Serviços injetados, nunca instanciados com `new`
- **Shared contracts**: Interfaces em Shared, implementações em Web/Maui
- **Atomic Design**: Atoms → Molecules → Organisms → Templates → Pages
- **CSS isolado**: Cada componente com seu `.razor.css`
- **Cores do tema**: `#2b2b2b` (fundo), `#ffffff` (texto), `#e8b827` (accent)
- **Responsivo**: breakpoint `768px`, max-width `1200px`

### 5. Testes
- Crie testes unitários em `tests/MeuSite.Tests/` com xUnit
- Teste ViewModels e lógica de negócio
- Execute com `dotnet test tests/MeuSite.Tests`

### 6. Verificação
- Compile o projeto: `dotnet build src/MeuSite.Web`
- Execute os testes: `dotnet test tests/MeuSite.Tests`
- Pergunte se deseja rodar para testar visualmente

## Após implementar
- Liste todos os arquivos criados/modificados
- Resuma o que foi feito
- Pergunte se deseja fazer commit
