<script lang="ts">
  import styles from './SkillBar.module.css';

  interface Props {
    name: string;
    percentage: number;
  }

  let { name, percentage }: Props = $props();

  const pct = $derived(Math.max(0, Math.min(100, percentage)));
</script>

<div class={styles.row}>
  <div class={styles.head}>
    <span class={styles.name}>{name}</span>
    <span class={styles.value}>{pct}%</span>
  </div>
  <div class={styles.track}>
    <div class={styles.fill} style:width="{pct}%"></div>
  </div>
</div>
