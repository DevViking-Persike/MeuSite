import type { ResumeModel } from '$lib/core/models/resume';
import type { ResumeRepository } from '$lib/server/resume/domain/resume-repository';

export async function getResumeUseCase(repository: ResumeRepository): Promise<ResumeModel> {
  return repository.getResume();
}
