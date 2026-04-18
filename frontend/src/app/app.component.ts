import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavigationBarElement } from './shared/models/NavigationBarElement';
import { RouterModule, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterModule, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'MyBlog';
  navigationButtons: NavigationBarElement[] = [];

  constructor() {
    this.navigationButtons = [
      {
        href: '/',
        label: 'Home',
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
