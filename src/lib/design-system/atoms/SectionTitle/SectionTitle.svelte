<script lang="ts">
  import styles from './SectionTitle.module.css';

  interface Props {
    title: string;
  }

  let { title }: Props = $props();
</script>

<div class={styles['section-title']}>
  <h2>{title}</h2>
</div>
