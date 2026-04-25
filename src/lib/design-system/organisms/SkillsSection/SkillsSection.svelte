<script lang="ts">
  import type { SkillCategory, SkillEntry } from '$lib/core/models/resume';
  import SectionHeader from '$lib/design-system/atoms/SectionHeader/SectionHeader.svelte';
  import SkillBar from '$lib/design-system/molecules/SkillBar/SkillBar.svelte';
  import styles from './SkillsSection.module.css';

  interface Props {
    skills: SkillEntry[];
  }

  let { skills }: Props = $props();

  const categoryLabels: Record<SkillCategory, string> = {
    languages: 'Linguagens',
    frontend: 'Frontend',
    backend: 'Backend',
    'cloud-devops': 'Cloud & DevOps'
  };

  const categoryOrder: SkillCategory[] = ['languages', 'frontend', 'backend', 'cloud-devops'];

  const grouped = $derived(
    categoryOrder
      .map((cat) => ({
        category: cat,
        label: categoryLabels[cat],
        items: skills.filter((s) => s.category === cat)
      }))
      .filter((g) => g.items.length > 0)
  );

  const ungrouped = $derived(skills.filter((s) => !s.category));
</script>

<section id="skills" class={styles.section}>
  <div class={styles.inner}>
    <SectionHeader
      number="03"
      label="Stack"
      title="Skills"
      description="Habilidades técnicas agrupadas por área. Foco principal em backend C#/.NET, frontend Angular/React e DevOps em nuvem."
    />

    <div class={styles.grid}>
      {#each grouped as group}
        <div class={styles.group}>
          <h3 class={styles.groupTitle}>
            <span class={styles.groupBullet}></span>
            {group.label}
          </h3>
          <div class={styles.list}>
            {#each group.items as skill}
              <SkillBar name={skill.name} percentage={skill.percentage} />
            {/each}
          </div>
        </div>
      {/each}

      {#if ungrouped.length > 0}
        <div class={styles.group}>
          <h3 class={styles.groupTitle}>
            <span class={styles.groupBullet}></span>
            Outras
          </h3>
          <div class={styles.list}>
            {#each ungrouped as skill}
              <SkillBar name={skill.name} percentage={skill.percentage} />
            {/each}
          </div>
        </div>
      {/if}
    </div>
  </div>
</section>
