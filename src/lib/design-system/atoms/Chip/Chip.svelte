<script lang="ts">
  import styles from './Chip.module.css';

  type Variant = 'default' | 'accent' | 'outline';

  interface Props {
    label: string;
    variant?: Variant;
  }

  let { label, variant = 'default' }: Props = $props();
</script>

<span class="{styles.chip} {styles[variant]}">{label}</span>
