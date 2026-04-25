<script lang="ts">
  import Icon from '$lib/design-system/atoms/Icon/Icon.svelte';
  import styles from './AppHeader.module.css';

  interface Props {
    name: string;
    githubUrl?: string;
    linkedinUrl?: string;
    cvHref?: string;
  }

  let { name, githubUrl, linkedinUrl, cvHref = '/docs/curriculo-persike.pdf' }: Props = $props();

  const initials = $derived(
    name
      .split(' ')
      .filter(Boolean)
      .slice(0, 2)
      .map((n) => n[0]?.toUpperCase() ?? '')
      .join('')
  );

  const navItems = [
    { href: '#sobre', label: 'Sobre' },
    { href: '#experiencia', label: 'Experiência' },
    { href: '#educacao', label: 'Educação' },
    { href: '#skills', label: 'Skills' }
  ];
</script>

<header class={styles.header}>
  <div class={styles.inner}>
    <a href="#sobre" class={styles.brand} aria-label="Início">
      <span class={styles.mark}>{initials}</span>
      <span class={styles.brandName}>{name}</span>
    </a>

    <nav class={styles.nav} aria-label="Seções">
      {#each navItems as item}
        <a href={item.href} class={styles.navLink}>{item.label}</a>
      {/each}
    </nav>

    <div class={styles.actions}>
      {#if linkedinUrl}
        <a
          href={linkedinUrl}
          class={styles.iconBtn}
          target="_blank"
          rel="noopener noreferrer"
          aria-label="LinkedIn"
        >
          <Icon name="linkedin" size={16} />
        </a>
      {/if}
      {#if githubUrl}
        <a
          href={githubUrl}
          class={styles.iconBtn}
          target="_blank"
          rel="noopener noreferrer"
          aria-label="GitHub"
        >
          <Icon name="github" size={16} />
        </a>
      {/if}
      <a href={cvHref} download class={styles.cta}>
        <Icon name="download" size={14} />
        <span>Baixar CV</span>
      </a>
    </div>
  </div>
</header>
