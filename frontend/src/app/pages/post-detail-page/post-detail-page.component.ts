import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, ActivatedRoute, Router } from '@angular/router';
import { PostService } from 'src/app/features/post/services/post.service';
import { GetPostsResponse } from 'src/app/features/post/models/getpost.models';

@Component({
  selector: 'app-post-detail-page',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './post-detail-page.component.html',
  styleUrls: ['./post-detail-page.component.css']
})
export class PostDetailPageComponent {
  post: GetPostsResponse | null = null;
  isLoading = false;
  errorMessage = '';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private postService: PostService
  ) {
  }

  ngOnInit() {
    console.log(this.route);
    
    const postId = this.route.snapshot.paramMap.get('postId');

    if (!postId) {
      this.errorMessage = 'Không tìm thấy bài viết.';
      return;
    }

    this.isLoading = true;
    this.postService.getPostById(postId).subscribe({
      next: (post) => {
        this.post = post ?? null;
        this.isLoading = false;

        if (!post) {
          this.errorMessage = 'Bài viết không tồn tại.';
        }
      },
      error: () => {
        this.errorMessage = 'Không tải được nội dung bài viết.';
        this.isLoading = false;
      }
    });
  }

  goBack() {
    this.router.navigate(['/posts']);
  }
}
