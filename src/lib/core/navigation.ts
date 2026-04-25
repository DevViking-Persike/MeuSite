export interface NavItem {
  id: string;
  label: string;
  href: string;
}

export const navigation: NavItem[] = [
  { id: 'resume', label: 'Currículo', href: '/' }
];
