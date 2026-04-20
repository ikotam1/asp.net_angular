import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostService } from 'src/app/features/post/services/post.service';

@Component({
  selector: 'app-posts-page',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './posts-page.component.html',
  styleUrls: ['./posts-page.component.css']
})
export class PostsPageComponent {

  constructor(private service: PostService) {
    
  }

  ngOnInit() {
    const state = history.state;
    state.userId = 'c75a0b43-366c-4bbb-b0f3-31d3ebf84593';
    console.log("AAAAAAAA");
    
    if (state?.userId) {
      this.service.getPostsByUserId({ userId: state.userId }).subscribe({
        next: (response) => {
          console.log("get post success: ", response);
        }
      });
    }
  }
}
