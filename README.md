# MeuSite — Portfolio Victor Persike

Currículo/portfólio web com SSR, construído em **SvelteKit 2 + Svelte 5**.

A arquitetura segue o modelo do projeto SeguraPro: design system atômico, camadas hexagonais no servidor (domain / application / infrastructure) e factory de repositórios selecionada por variável de ambiente.

## Pré-requisitos

- Node 22+
- pnpm 10 (`corepack enable`)

## Como rodar

```bash
pnpm install
pnpm dev          # http://localhost:5173
```

## Build de produção

```bash
pnpm build
pnpm start        # node build/index.js
```

## Docker

```bash
docker compose up -d   # http://localhost:5173
docker compose logs -f web
docker compose down
```

## Script utilitário

```bash
./run.sh help
./run.sh dev
./run.sh build
./run.sh docker-up
```

## Variáveis de ambiente

| Var                          | Default  | Descrição                                    |
| ---------------------------- | -------- | -------------------------------------------- |
| `MEUSITE_BACKEND_PROVIDER`   | `static` | Repositório de dados (atualmente só estático) |
| `BASE_PATH`                  | (vazio)  | Prefixo de rota (ex.: `/portfolio`)          |
| `PORT`                       | `5173`   | Porta do servidor adapter-node               |
| `HOST`                       | `0.0.0.0`| Host do servidor adapter-node                |

## Estrutura

```
src/
├── app.html / app.css / app.d.ts / hooks.server.ts
├── lib/
│   ├── core/{models,utils,navigation.ts}
│   ├── platform/runtime.ts
│   ├── design-system/{atoms,molecules,organisms,templates}/
│   ├── features/resume/view/
│   └── server/
│       ├── shared/config/
│       └── resume/{domain,application,infrastructure}/
└── routes/
    ├── +layout.svelte
    ├── +page.server.ts   # SSR loader
    └── +page.svelte
```

## Convenções

- **SSR-first**: dados carregados em `+page.server.ts` via use case
- **Hexagonal**: `domain` (interface) → `application` (use case) → `infrastructure` (impl + factory)
- **Atomic design**: atoms → molecules → organisms → templates
- **CSS Modules** + `var(--token)` em `app.css`
- **Svelte 5 runes** (`$state`, `$derived`, `$props`)
