# ADR 0004: Estrutura de Componentes com Atomic Design

## Status
Aceito

## Contexto
A UI precisa de uma estrutura organizada e escalável. Com múltiplos componentes Blazor, é necessário um sistema de categorização.

## Decisão
Adotar Atomic Design com as seguintes camadas:
- **Atoms**: Elementos indivisíveis (SectionTitle, ProfilePhoto, SkillCircle, DecorativeDots, ContactIcon).
- **Molecules**: Combinações de Atoms com uma função específica (ContactItem, EducationEntryItem, SkillItem, ExperienceCard).
- **Organisms**: Seções completas da página compostas por Molecules (HeroSection, ContactSidebar, EducationSection, ExperienceSection, SkillsSection).
- **Templates**: Layouts estruturais (ResumeLayout).
- **Pages**: Páginas roteáveis que orquestram Organisms (ResumePage).

## Alternativas Consideradas
1. **Pasta plana**: Todos os componentes em uma pasta. Descartado por falta de organização em escala.
2. **Feature-based**: Pastas por feature (Hero/, Education/, etc.). Válido, mas Atomic Design é mais universal e escalável.

## Consequências
- **Positivo**: Hierarquia clara e previsível.
- **Positivo**: Facilita code review e onboarding.
- **Negativo**: Pode ser over-engineering para projetos muito pequenos (mitigado pelo objetivo de crescimento futuro).
