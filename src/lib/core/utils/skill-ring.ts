const DEFAULT_RADIUS = 54;

export function getCircumference(radius = DEFAULT_RADIUS): number {
  return 2 * Math.PI * radius;
}

export function getStrokeDashoffset(percentage: number, radius = DEFAULT_RADIUS): number {
  const circumference = getCircumference(radius);
  return circumference - (percentage / 100) * circumference;
}
