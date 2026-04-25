# MeuSite — Portfolio Victor Persike

Currículo/portfólio em **SvelteKit 2 + Svelte 5** com SSR (`adapter-node`), seguindo a arquitetura do projeto SeguraPro: design system atômico + camadas hexagonais no servidor + factory de repositórios.

## Estrutura

```
MeuSite/
├── package.json / svelte.config.js / vite.config.ts / tsconfig.json
├── Dockerfile / docker-compose.yml / run.sh
├── static/
│   ├── images/        # profile.jpg, favicon.svg, profile-placeholder.svg
│   └── docs/          # curriculo-persike.pdf
├── src/
│   ├── app.html / app.css / app.d.ts
│   ├── hooks.server.ts
│   ├── lib/
│   │   ├── core/
│   │   │   ├── models/     # tipos TS (ResumeModel, ContactInfo…)
│   │   │   ├── utils/      # helpers (skill-ring)
│   │   │   └── navigation.ts
│   │   ├── platform/runtime.ts
│   │   ├── design-system/  # atoms → molecules → organisms → templates
│   │   ├── features/
│   │   │   └── resume/view/ResumeView.svelte
│   │   └── server/
│   │       ├── shared/config/server-config.ts
│   │       └── resume/
│   │           ├── domain/resume-repository.ts          # interface
│   │           ├── application/get-resume.ts            # use case
│   │           └── infrastructure/
│   │               ├── static-resume-repository.ts      # dados hardcoded
│   │               └── resume-repository-factory.ts
│   └── routes/
│       ├── +layout.svelte
│       ├── +page.server.ts   # carrega resume via factory
│       └── +page.svelte
└── src.dotnet-backup/        # backup da versão .NET (descartável)
```

## Padrões obrigatórios

- **SSR-first**: dados carregados em `+page.server.ts` via use case
- **Hexagonal server**: domain (interface) → application (use case) → infrastructure (impl + factory)
- **Factory por env**: `MEUSITE_BACKEND_PROVIDER=static` (default) decide repositório
- **Design system atômico**: atoms → molecules → organisms → templates
- **CSS Modules**: cada componente com `.module.css`, sem `<style>` inline
- **CSS tokens**: `var(--token)` definidos em `src/app.css`
- **Svelte 5 runes**: `$state()`, `$derived()`, `$props()`

## Como rodar

```bash
pnpm install              # ou ./run.sh install
pnpm dev                  # http://localhost:5173

pnpm build && pnpm start  # produção (adapter-node)

docker compose up -d      # produção em container
```

## Stack

- SvelteKit 2 + Svelte 5
- TypeScript 5
- Vite 6
- adapter-node 5
- Vitest

## O que NÃO fazer

- Não usar `<style>` inline nos `.svelte` (CSS Modules ou tokens em `app.css`)
- Não hardcodear cores hex (usar `var(--token)`)
- Não ler dados em `+page.svelte` — usar `+page.server.ts` + use case
- Não importar dados estáticos diretamente nas views (passar via `$props()`)
