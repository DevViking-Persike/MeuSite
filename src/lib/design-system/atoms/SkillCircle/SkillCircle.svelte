<script lang="ts">
  import { getCircumference, getStrokeDashoffset } from '$lib/core/utils/skill-ring';
  import styles from './SkillCircle.module.css';

  interface Props {
    percentage: number;
  }

  let { percentage }: Props = $props();

  const circumference = $derived(getCircumference());
  const dashOffset = $derived(getStrokeDashoffset(percentage));
</script>

<div class={styles['skill-circle']}>
  <svg viewBox="0 0 120 120">
    <circle class={styles.bg} cx="60" cy="60" r="54" />
    <circle
      class={styles.progress}
      cx="60"
      cy="60"
      r="54"
      stroke-dasharray={circumference}
      stroke-dashoffset={dashOffset}
    />
  </svg>
  <span class={styles.percentage}>{percentage}%</span>
</div>
