import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavigationBarElement } from 'src/app/shared/models/NavigationBarElement';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
  navigationButtons: NavigationBarElement[] = [];

  constructor() {
    this.navigationButtons = [
      {
        href: '/',
        label: 'Home',
      },
      {
        href: '/posts',
        label: 'My Wall',
      },
      {
        href: '/explore',
        label: 'Explore',
      },
      {
        href: '/about',
        label: 'About',
      },
      {
        href: '/auth/login',
        label: 'Login',
      }
    ];
  }
}
