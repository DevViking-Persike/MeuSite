<script lang="ts">
  import type { Snippet } from 'svelte';
  import styles from './IconLink.module.css';

  type Variant = 'default' | 'primary' | 'ghost';

  interface Props {
    href: string;
    label: string;
    icon: Snippet;
    variant?: Variant;
    download?: boolean;
    external?: boolean;
    ariaLabel?: string;
  }

  let {
    href,
    label,
    icon,
    variant = 'default',
    download = false,
    external = false,
    ariaLabel
  }: Props = $props();
</script>

<a
  {href}
  class="{styles.link} {styles[variant]}"
  download={download ? '' : undefined}
  target={external ? '_blank' : undefined}
  rel={external ? 'noopener noreferrer' : undefined}
  aria-label={ariaLabel ?? label}
>
  <span class={styles.icon}>{@render icon()}</span>
  <span class={styles.label}>{label}</span>
</a>
