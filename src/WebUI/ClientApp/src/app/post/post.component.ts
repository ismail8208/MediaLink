import { Component, OnInit } from '@angular/core';
import { PaginatedListOfPostDto, Post, PostDto, PostsClient, UserDto, UsersClient} from '../web-api-client';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
@Component({
  selector: 'app-post',
  templateUrl: './post.component.html'
})
export class PostComponent implements OnInit {

  user: UserDto;
  constructor(private authorizeService: AuthorizeService) {
  }

  ngOnInit(): void {
    this.authorizeService.getUserInfo().subscribe({
      next: data => this.user = data
    })
  }
}
