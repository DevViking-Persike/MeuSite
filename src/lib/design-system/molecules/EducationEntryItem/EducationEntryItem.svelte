<script lang="ts">
  import styles from './EducationEntryItem.module.css';

  interface Props {
    period: string;
    institution: string;
    degree: string;
  }

  let { period, institution, degree }: Props = $props();
</script>

<div class={styles['education-entry']}>
  <span class={styles.period}>{period}</span>
  <h4 class={styles.institution}>{institution}</h4>
  <ul>
    <li class={styles.degree}>{degree}</li>
  </ul>
</div>
