<script lang="ts">
  import type { ContactInfo, SocialLinks } from '$lib/core/models/resume';
  import Icon from '$lib/design-system/atoms/Icon/Icon.svelte';
  import styles from './Footer.module.css';

  interface Props {
    name: string;
    title: string;
    contact: ContactInfo;
    socials: SocialLinks;
  }

  let { name, title, contact, socials }: Props = $props();

  const year = new Date().getFullYear();
</script>

<footer id="contato" class={styles.footer}>
  <div class={styles.inner}>
    <div class={styles.top}>
      <div class={styles.identity}>
        <h3 class={styles.heading}>Vamos conversar</h3>
        <p class={styles.lead}>
          Aberto a oportunidades, parcerias e projetos. A melhor forma de me chamar é por email.
        </p>
        <a class={styles.emailCta} href="mailto:{contact.email}">
          {contact.email}
          <span class={styles.arrow} aria-hidden="true">→</span>
        </a>
      </div>

      <div class={styles.linksCol}>
        <h4 class={styles.colTitle}>Contato</h4>
        <ul class={styles.list}>
          <li>
            <a href="mailto:{contact.email}" class={styles.link}>
              <Icon name="email" size={14} />
              <span>{contact.email}</span>
            </a>
          </li>
          <li>
            <a href="tel:{contact.phone.replace(/\s+/g, '')}" class={styles.link}>
              <Icon name="phone" size={14} />
              <span>{contact.phone}</span>
            </a>
          </li>
          <li>
            <a
              href="https://{contact.website}"
              class={styles.link}
              target="_blank"
              rel="noopener noreferrer"
            >
              <Icon name="globe" size={14} />
              <span>{contact.website}</span>
            </a>
          </li>
        </ul>
      </div>

      <div class={styles.linksCol}>
        <h4 class={styles.colTitle}>Redes</h4>
        <ul class={styles.list}>
          {#if socials.github}
            <li>
              <a href={socials.github} class={styles.link} target="_blank" rel="noopener noreferrer">
                <Icon name="github" size={14} />
                <span>GitHub</span>
              </a>
            </li>
          {/if}
          {#if socials.linkedin}
            <li>
              <a
                href={socials.linkedin}
                class={styles.link}
                target="_blank"
                rel="noopener noreferrer"
              >
                <Icon name="linkedin" size={14} />
                <span>LinkedIn</span>
              </a>
            </li>
          {/if}
          <li>
            <a href="/docs/curriculo-persike.pdf" class={styles.link} download>
              <Icon name="download" size={14} />
              <span>Baixar CV</span>
            </a>
          </li>
        </ul>
      </div>
    </div>

    <div class={styles.bottom}>
      <p class={styles.copy}>© {year} {name} · {title}</p>
      <p class={styles.tech}>
        Construído com <span class={styles.mono}>SvelteKit</span> ·
        <span class={styles.mono}>TypeScript</span>
      </p>
    </div>
  </div>
</footer>
