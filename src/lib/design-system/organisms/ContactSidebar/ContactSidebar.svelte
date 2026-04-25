<script lang="ts">
  import type { ContactInfo } from '$lib/core/models/resume';
  import ContactItem from '$lib/design-system/molecules/ContactItem/ContactItem.svelte';
  import styles from './ContactSidebar.module.css';

  interface Props {
    contact: ContactInfo;
  }

  let { contact }: Props = $props();
</script>

<aside class={styles['contact-sidebar']}>
  <h3 class={styles['sidebar-title']}>Contato</h3>
  <ContactItem label="Celular" value={contact.phone} />
  <ContactItem label="Email" value={contact.email} />
  <ContactItem label="Website" value={contact.website} />
</aside>
