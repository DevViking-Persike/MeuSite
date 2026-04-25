<script lang="ts">
  import type { Snippet } from 'svelte';
  import ResumeLayout from '$lib/design-system/templates/ResumeLayout/ResumeLayout.svelte';
  import '../app.css';

  let { children }: { children?: Snippet } = $props();
</script>

<ResumeLayout>
  {@render children?.()}
</ResumeLayout>
