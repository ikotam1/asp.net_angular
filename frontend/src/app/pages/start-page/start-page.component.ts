import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Feature } from '../../shared/models/Feature';

@Component({
  selector: 'main-content',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './start-page.component.html',
  styleUrls: ['./start-page.component.scss']
})
export class StartPageComponent {
  features: Feature[];

  constructor() {
    this.features = [
      {
        title: 'Read Posts',
        description: 'Explore interesting blog posts from our community',
        icon: '📖'
      },
      {
        title: 'Create Content',
        description: 'Share your thoughts and ideas with the world',
        icon: '✍️'
      },
      {
        title: 'Connect',
        description: 'Engage with other writers and readers',
        icon: '🤝'
      },
      {
        title: 'Discover',
        description: 'Find new topics and perspectives',
        icon: '🔍'
      }
    ];
  }
}
