using MeuSite.Shared.Contracts;
using MeuSite.Shared.Models;

namespace MeuSite.Web.Services;

public class ResumeDataProvider : IResumeDataProvider
{
    public Task<ResumeModel> GetResumeAsync()
    {
        var resume = new ResumeModel
        {
            FullName = "Victor Persike",
            Title = "Desenvolvedor Full-Stack",
            ProfileImageUrl = "_content/MeuSite.Ui/images/profile.jpg",
            AboutMe = "Tenho 9 anos de experiência na área da educação, atuando na formação de professores e no ensino básico, com foco em treinamentos em oficinas maker. Em 2018, decidi mudar de carreira e me especializar no desenvolvimento front-end. Desde então, trabalhei com tecnologias como WordPress e Moodle, além de desenvolver projetos com Angular, Node.js, Ionic e Nz-Zorro. Mais recentemente, tenho me dedicado ao uso de React, C#, SQL Server e Azure DevOps. Além disso, venho expandindo meus conhecimentos em linguagens como Python e Go, explorando suas possibilidades em projetos pessoais e buscando novas oportunidades de aprendizado e inovação.",
            Contact = new ContactInfo
            {
                Phone = "+55 11 95705-7466",
                Address = "Rua Doutor Domingos Guedes Cabral 236, apto 07, Mandaqui",
                Email = "dev.victor.persike@gmail.com",
                Website = "www.victorpersike.dev.br"
            },
            Education = new List<EducationEntry>
            {
                new() { Period = "2022 - 2026", Institution = "Faculdade Descomplica", Degree = "Ciências da Computação EAD" },
                new() { Period = "2021 - 2022", Institution = "RecodePro", Degree = "Programação FullStack 520 horas" },
                new() { Period = "2012 - 2022", Institution = "Universidade de São Paulo", Degree = "Licenciatura em Física" },
                new() { Period = "2019/06 - 2019/11", Institution = "SP Escola de Teatro", Degree = "Game Design - Criando jogos, do tabuleiro ao digital" },
                new() { Period = "2024 - 2025/07", Institution = "Full Cycle", Degree = "MBA Arquitetura Full Cycle" },
                new() { Period = "2026 - 2027/02", Institution = "Full Cycle", Degree = "MBA em Engenharia de Software com IA" }
            },
            Experiences = new List<ExperienceEntry>
            {
                new() { Company = "Usucampeão", Role = "Desenvolvedor Full-Stack", Period = "06/21 - 07/22", Description = "Durante meu período na Usucampeão, atuei como desenvolvedor fullstack júnior, contribuindo com o desenvolvimento de aplicações utilizando Angular e Ionic no front-end e NestJS no back-end. Trabalhei com Akita para gerenciamento de estado e participei da criação de interfaces com o Zorro em um sistema de gestão integrado a um app mobile. No back-end, desenvolvi e integrei APIs RESTful, além de implementar recursos com Firebase, como autenticação, banco de dados em tempo real e notificações. Também tive a oportunidade de participar da construção de uma PWA (Progressive Web App), focando em oferecer uma experiência fluida e próxima de um aplicativo nativo. Essa experiência foi essencial para consolidar meus conhecimentos em desenvolvimento fullstack e me aproximar das boas práticas em projetos modernos e escaláveis." },
                new() { Company = "AR3 Capital", Role = "Desenvolvedor Full-Cycle", Period = "07/22 - 04/23", Description = "Na AR3, atuei como desenvolvedor fullstack focado na manutenção e evolução de sistemas legados. No front usei React e no back C#/.NET com SQL Server (EF e Dapper), aplicando Clean Code e SOLID com forte visão de refatoração. Também participei de sustentação, suporte técnico e priorização de demandas, além de DevOps na Azure com pipelines, em rotina ágil (Scrum/Jira)." },
                new() { Company = "Saúde One", Role = "Desenvolvedor Full-Stack", Period = "04/23 - 10/23", Description = "Na Saúde One, atuei no desenvolvimento front-end com Angular e back-end com C# em sistemas legados com SQL Server. Trabalhei com DevOps na Azure, seguindo Scrum e utilizando Jira para gestão. Apliquei DDD, Clean Code, SOLID e testes automatizados. Também gerenciei equipe de sustentação, planejei projetos e integrei serviços externos. Tecnologias: .NET 5, Dapper, Entity Framework." },
                new() { Company = "Ingram Micro", Role = "Desenvolvedor Full-Stack", Period = "10/23 - 11/24", Description = "Na Ingram, atuei na squad de contabilidade desenvolvendo soluções para automação de processos contábeis. No front-end, trabalhei com MVC em C# e jQuery em sistemas legados e com React utilizando micro front-ends. No back-end, desenvolvi microsserviços em C#, além de gerenciar o ambiente on-premise com servidores Windows, sendo responsável por atividades de DevOps, incluindo deploy e manutenção contínua dos sistemas." },
                new() { Company = "Totvs Meu Protheus", Role = "Desenvolvedor Mobile", Period = "07/23 - 02/24", Description = "Na TOTVS, participei do desenvolvimento de aplicativos móveis com Angular 15 e Ionic, integrando serviços do Firebase para autenticação e envio de notificações push. Contribuí para a entrega de funcionalidades avançadas e uma experiência de usuário otimizada." },
                new() { Company = "Caixa Vida e Previdência", Role = "Desenvolvedor Full-Stack", Period = "12/24 - 11/25", Description = "Atualmente, atuo na Caixa Vida e Previdência como desenvolvedor fullstack, com foco no back-end em C#, desenvolvendo microsserviços e soluções em gateway de autenticação e gestão de arquivos. No front-end, contribuo com a implementação de interfaces utilizando React, garantindo integração eficiente entre as camadas e uma experiência de uso consistente." },
                new() { Company = "Avita", Role = "Desenvolvedor Full-Stack", Period = "11/25 - Atual", Description = "Atuo como Fullstack Senior em um ecossistema de microserviços, com foco em Angular no front-end e C#/.NET no back-end. Desenvolvo e evoluo APIs em um microserviço dedicado usando Dapper, garantindo performance e consistência nas regras de negócio. Também integro e faço a sustentação de autenticação/autorização com Keycloak, trabalhando com JWT e fluxos de SSO. Implemento comunicação assíncrona e eventos com RabbitMQ, além de integrações com diversos serviços para processos de apólices de seguros, validações e automações. No dia a dia, uso GitLab (CI/CD) e AWS." }
            },
            Skills = new List<SkillEntry>
            {
                new() { Name = "C#", Percentage = 80 },
                new() { Name = "Angular, React", Percentage = 70 },
                new() { Name = "DevOps, Azure, AWS", Percentage = 70 },
                new() { Name = "JavaScript", Percentage = 70 },
                new() { Name = "Docker", Percentage = 75 },
                new() { Name = "Python / Rust", Percentage = 57 }
            }
        };

        return Task.FromResult(resume);
    }
}
