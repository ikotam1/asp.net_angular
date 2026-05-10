import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { PostService } from 'src/app/features/post/services/post.service';
import { CreatePostRequest, GetPostsResponse } from 'src/app/features/post/models/getpost.models';

@Component({
  selector: 'app-posts-page',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './posts-page.component.html',
  styleUrls: ['./posts-page.component.css']
})
export class PostsPageComponent {
  posts: GetPostsResponse[] = [];
  isLoading = false;
  isSubmitting = false;
  errorMessage = '';

  newPost: CreatePostRequest = {
    title: '',
    content: ''
  };

  constructor(private service: PostService) {
  }

  ngOnInit() {
    this.loadPosts();
  }

  loadPosts() {
    this.isLoading = true;
    this.errorMessage = '';

    this.service.getPostsByUserId().subscribe({
      next: (response) => {
        this.posts = response || [];
        this.isLoading = false;
      },
      error: () => {
        this.errorMessage = 'Không thể tải danh sách bài viết.';
        this.isLoading = false;
      }
    });
  }

  submitPost() {
    if (!this.newPost.title.trim() || !this.newPost.content.trim()) {
      return;
    }

    this.isSubmitting = true;
    this.errorMessage = '';

    this.service.createPost(this.newPost).subscribe({
      next: () => {
        this.newPost = { title: '', content: '' };
        this.loadPosts();
        this.isSubmitting = false;
      },
      error: () => {
        this.errorMessage = 'Đăng bài thất bại, vui lòng thử lại.';
        this.isSubmitting = false;
      }
    });
  }
}
