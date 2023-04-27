import { Component } from '@angular/core';
import { PaginatedListOfPostDto, Post, PostDto, PostsClient} from '../web-api-client';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html'
})
export class PostComponent {
  public posts: PostDto [] = [];

  constructor(private client: PostsClient) {
    client.getPostsWithPagination(3, 1, 2).subscribe(result => {
      this.posts = result.items;
    }, error => console.error(error));
  }
}
