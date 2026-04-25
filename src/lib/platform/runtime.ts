export type RuntimeTarget = 'web' | 'tauri';

export function resolveRuntimeTarget(): RuntimeTarget {
  if (typeof window !== 'undefined' && '__TAURI_INTERNALS__' in window) {
    return 'tauri';
  }
  return 'web';
}
