import { env } from '$env/dynamic/private';

export type BackendProvider = 'static';

export function getBackendProvider(): BackendProvider {
  return (env.MEUSITE_BACKEND_PROVIDER as BackendProvider) ?? 'static';
}
