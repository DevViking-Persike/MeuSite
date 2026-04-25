<script lang="ts">
  import styles from './DecorativeDots.module.css';

  interface Props {
    rows?: number;
    columns?: number;
  }

  let { rows = 5, columns = 4 }: Props = $props();

  const grid = $derived(
    Array.from({ length: rows }, () => Array.from({ length: columns }, (_, i) => i))
  );
</script>

<div class={styles['decorative-dots']} aria-hidden="true">
  {#each grid as row}
    <div class={styles['dot-row']}>
      {#each row as col (col)}
        <span class={styles.dot}></span>
      {/each}
    </div>
  {/each}
</div>
