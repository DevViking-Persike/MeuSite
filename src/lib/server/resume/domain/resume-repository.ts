import type { ResumeModel } from '$lib/core/models/resume';

export interface ResumeRepository {
  getResume(): Promise<ResumeModel>;
}
