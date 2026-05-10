import { ApiService } from "src/app/core/services/api.service";
import { CreatePostRequest, GetPostsResponse } from "../models/getpost.models";
import { Injectable } from "@angular/core";
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  private serviceUrl = 'post/';

  constructor(private apiService: ApiService) {
  }

  getPostsByUserId() {
    return this.apiService.get<GetPostsResponse[]>(`${this.serviceUrl}`);
  }

  getPostById(postId: string) {
    return this.apiService.get<GetPostsResponse>(`${this.serviceUrl}${postId}`);
  }

  createPost(request: CreatePostRequest) {
    return this.apiService.post<any>(`${this.serviceUrl}`, request);
  }
}