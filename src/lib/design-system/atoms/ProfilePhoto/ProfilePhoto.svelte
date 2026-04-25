<script lang="ts">
  import styles from './ProfilePhoto.module.css';

  interface Props {
    src?: string;
    alt?: string;
  }

  let { src = '/images/profile-placeholder.svg', alt = 'Profile photo' }: Props = $props();
</script>

<div class={styles['profile-photo']}>
  <img {src} {alt} />
</div>
