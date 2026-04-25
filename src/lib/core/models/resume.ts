export interface ContactInfo {
  phone: string;
  email: string;
  website: string;
}

export interface SocialLinks {
  github?: string;
  linkedin?: string;
}

export interface EducationEntry {
  period: string;
  institution: string;
  degree: string;
}

export interface ExperienceEntry {
  company: string;
  role: string;
  period: string;
  description: string;
  techs?: string[];
  current?: boolean;
}

export type SkillCategory = 'languages' | 'frontend' | 'backend' | 'cloud-devops';

export interface SkillEntry {
  name: string;
  percentage: number;
  category?: SkillCategory;
}

export interface ResumeModel {
  fullName: string;
  title: string;
  aboutMe: string;
  profileImageUrl: string;
  contact: ContactInfo;
  socials: SocialLinks;
  highlightStack: string[];
  education: EducationEntry[];
  experiences: ExperienceEntry[];
  skills: SkillEntry[];
}
