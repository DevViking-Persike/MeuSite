<script lang="ts">
  import Chip from '$lib/design-system/atoms/Chip/Chip.svelte';
  import styles from './ExperienceCard.module.css';

  interface Props {
    company: string;
    role: string;
    period: string;
    description: string;
    techs?: string[];
    current?: boolean;
  }

  let { company, role, period, description, techs = [], current = false }: Props = $props();
</script>

<article class={styles.item}>
  <div class={styles.timeline} aria-hidden="true">
    <span class="{styles.dot} {current ? styles.dotCurrent : ''}"></span>
    <span class={styles.line}></span>
  </div>

  <div class={styles.card}>
    <header class={styles.head}>
      <div class={styles.heading}>
        <h3 class={styles.company}>
          {company}
          {#if current}
            <span class={styles.badge}>Atual</span>
          {/if}
        </h3>
        <p class={styles.role}>{role}</p>
      </div>
      <span class={styles.period}>{period}</span>
    </header>

    <p class={styles.description}>{description}</p>

    {#if techs.length > 0}
      <div class={styles.techs}>
        {#each techs as tech}
          <Chip label={tech} variant="outline" />
        {/each}
      </div>
    {/if}
  </div>
</article>
