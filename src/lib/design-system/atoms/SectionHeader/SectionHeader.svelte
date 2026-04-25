<script lang="ts">
  import styles from './SectionHeader.module.css';

  interface Props {
    number: string;
    label: string;
    title: string;
    description?: string;
  }

  let { number, label, title, description }: Props = $props();
</script>

<header class={styles.header}>
  <div class={styles.eyebrow}>
    <span class={styles.number}>{number}</span>
    <span class={styles.divider}></span>
    <span class={styles.label}>{label}</span>
  </div>
  <h2 class={styles.title}>{title}</h2>
  {#if description}
    <p class={styles.description}>{description}</p>
  {/if}
</header>
