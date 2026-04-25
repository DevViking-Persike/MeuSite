<script lang="ts">
  import type { Snippet } from 'svelte';
  import styles from './ResumeLayout.module.css';

  interface Props {
    children?: Snippet;
  }

  let { children }: Props = $props();
</script>

<div class={styles['resume-layout']}>
  {@render children?.()}
</div>
