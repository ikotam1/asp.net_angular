import { ApiService } from "src/app/core/services/api.service";
import { GetPostsRequest } from "../models/getpost.models";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class PostService {
    private serviceUrl = 'Post/'
      constructor(private apiService: ApiService) {
      }

      getPostsByUserId(credentials: GetPostsRequest) {
        return this.apiService.get<GetPostsRequest>(`${this.serviceUrl}`);
      }
}