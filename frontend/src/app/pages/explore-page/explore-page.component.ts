import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostService } from 'src/app/features/post/services/post.service';

@Component({
  selector: 'app-explore-page',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './explore-page.component.html',
  styleUrls: ['./explore-page.component.css']
})
export class ExplorePageComponent {
}
