<script lang="ts">
  import ResumeView from '$lib/features/resume/view/ResumeView.svelte';

  let { data } = $props();
</script>

<svelte:head>
  <title>Victor Persike — Desenvolvedor Full-Stack</title>
  <meta name="description" content="Currículo de Victor Persike, desenvolvedor full-stack." />
</svelte:head>

<ResumeView resume={data.resume} />
