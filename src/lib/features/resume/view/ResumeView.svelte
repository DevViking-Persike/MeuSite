<script lang="ts">
  import type { ResumeModel } from '$lib/core/models/resume';
  import AppHeader from '$lib/design-system/organisms/AppHeader/AppHeader.svelte';
  import HeroSection from '$lib/design-system/organisms/HeroSection/HeroSection.svelte';
  import EducationSection from '$lib/design-system/organisms/EducationSection/EducationSection.svelte';
  import ExperienceSection from '$lib/design-system/organisms/ExperienceSection/ExperienceSection.svelte';
  import SkillsSection from '$lib/design-system/organisms/SkillsSection/SkillsSection.svelte';
  import Footer from '$lib/design-system/organisms/Footer/Footer.svelte';

  interface Props {
    resume: ResumeModel;
  }

  let { resume }: Props = $props();

  const currentRole = $derived.by(() => {
    const cur = resume.experiences.find((e) => e.current);
    return cur ? `${cur.company} · ${cur.role}` : undefined;
  });
</script>

<AppHeader
  name={resume.fullName}
  githubUrl={resume.socials.github}
  linkedinUrl={resume.socials.linkedin}
/>

<HeroSection
  name={resume.fullName}
  title={resume.title}
  profileImage={resume.profileImageUrl}
  aboutMe={resume.aboutMe}
  highlightStack={resume.highlightStack}
  email={resume.contact.email}
  githubUrl={resume.socials.github}
  linkedinUrl={resume.socials.linkedin}
  currentRole={currentRole}
/>

<ExperienceSection experiences={resume.experiences} />
<EducationSection education={resume.education} />
<SkillsSection skills={resume.skills} />

<Footer
  name={resume.fullName}
  title={resume.title}
  contact={resume.contact}
  socials={resume.socials}
/>
