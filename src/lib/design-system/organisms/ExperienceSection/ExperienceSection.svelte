<script lang="ts">
  import type { ExperienceEntry } from '$lib/core/models/resume';
  import SectionHeader from '$lib/design-system/atoms/SectionHeader/SectionHeader.svelte';
  import ExperienceCard from '$lib/design-system/molecules/ExperienceCard/ExperienceCard.svelte';
  import styles from './ExperienceSection.module.css';

  interface Props {
    experiences: ExperienceEntry[];
  }

  let { experiences }: Props = $props();
</script>

<section id="experiencia" class={styles.section}>
  <div class={styles.inner}>
    <SectionHeader
      number="01"
      label="Trajetória"
      title="Experiência"
      description="Atualmente atuando como Fullstack Senior. Histórico de entregas em microsserviços, integrações, sustentação e DevOps em empresas de seguros, saúde, contabilidade e mobile."
    />

    <div class={styles.timeline}>
      {#each experiences as exp}
        <ExperienceCard
          company={exp.company}
          role={exp.role}
          period={exp.period}
          description={exp.description}
          techs={exp.techs}
          current={exp.current}
        />
      {/each}
    </div>
  </div>
</section>
