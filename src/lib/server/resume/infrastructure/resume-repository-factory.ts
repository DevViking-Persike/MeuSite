import type { ResumeRepository } from '$lib/server/resume/domain/resume-repository';
import { StaticResumeRepository } from '$lib/server/resume/infrastructure/static-resume-repository';
import { getBackendProvider } from '$lib/server/shared/config/server-config';

export function createResumeRepository(): ResumeRepository {
  switch (getBackendProvider()) {
    case 'static':
    default:
      return new StaticResumeRepository();
  }
}
