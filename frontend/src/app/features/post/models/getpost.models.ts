export interface GetPostsResponse {
  id: string;
  title: string;
  content: string;
  authorName: string;
}

export interface CreatePostRequest {
  title: string;
  content: string;
}
