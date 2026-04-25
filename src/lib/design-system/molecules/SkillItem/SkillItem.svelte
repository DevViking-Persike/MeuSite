<script lang="ts">
  import SkillCircle from '$lib/design-system/atoms/SkillCircle/SkillCircle.svelte';
  import styles from './SkillItem.module.css';

  interface Props {
    name: string;
    percentage: number;
  }

  let { name, percentage }: Props = $props();
</script>

<div class={styles['skill-item']}>
  <SkillCircle {percentage} />
  <span class={styles['skill-name']}>{name}</span>
</div>
