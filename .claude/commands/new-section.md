Crie uma nova seção para uma página existente no projeto MeuSite.

O usuário vai informar: $ARGUMENTS

Extraia do argumento:
- **Nome da seção** (ex: "ProjectsSection", "CertificationsSection")
- **Página destino** - se não informada, assume ResumePage

## Passos

### 1. Model (se necessário)
- Crie em `src/MeuSite.Shared/Models/` como `record`
- Exemplo: `public record CertificationEntry(string Name, string Issuer, string Year);`

### 2. Atualizar ResumeModel (se dados novos)
- Adicione a propriedade no `src/MeuSite.Shared/Models/ResumeModel.cs`
- Atualize `IResumeDataProvider` se necessário

### 3. Atualizar ViewModel
- Adicione propriedades no `src/MeuSite.Ui/ViewModels/ResumePageViewModel.cs`
- Exponha dados formatados para a view

### 4. Criar Organism
- Crie `src/MeuSite.Ui/Components/Organisms/{Nome}.razor`
- Crie `src/MeuSite.Ui/Components/Organisms/{Nome}.razor.css`
- Injete o ViewModel: `@inject ResumePageViewModel ViewModel`
- Use SectionTitle atom para o título da seção

### 5. Criar Molecules (se necessário)
- Itens repetidos da seção devem ser Molecules
- Exemplo: `CertificationItem.razor` para cada certificação

### 6. Adicionar na página
- Insira o Organism em `src/MeuSite.Ui/Components/Pages/ResumePage.razor`
- Posicione na ordem visual desejada

### 7. Dados mockados
- Atualize `WebResumeDataProvider.cs` e `MauiResumeDataProvider.cs`

## Padrão visual
- Fundo seção: `#2b2b2b`
- Título seção: `#e8b827`, font-weight 700
- Texto: `#ffffff` (principal), `#cccccc` (secundário)
- Padding: `2rem 2.5rem`
- Responsivo com `@@media (max-width: 768px)`
- Grid ou flex layout conforme o conteúdo

## Após criar
- Liste todos os arquivos criados/modificados
- Pergunte se deseja rodar para ver o resultado
