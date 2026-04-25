<script lang="ts">
  import styles from './ContactItem.module.css';

  interface Props {
    label: string;
    value: string;
  }

  let { label, value }: Props = $props();
</script>

<div class={styles['contact-item']}>
  <h4 class={styles['contact-label']}>{label}</h4>
  <p class={styles['contact-value']}>{value}</p>
</div>
