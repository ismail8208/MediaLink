
import { Component, OnInit, TemplateRef } from '@angular/core';
import {FileParameter, IUserDto, PostsClient} from '../../web-api-client';
import { Store, select } from '@ngrx/store';
import { selectUser } from 'src/app/stateManagement/user.selectors';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-addPostCard',
  templateUrl: './addPostCard.component.html',
  styleUrls: ['./addPostCard.component.css']
})

export class AddPostCardComponent implements OnInit {
  debug = false;
  newPostEditor: any = {};
  newPostModalRef: BsModalRef;
  user: IUserDto;
  constructor(private store: Store, private modalService: BsModalService ,private postsClinte: PostsClient){}
  ngOnInit(): void {
    
    this.store.pipe(select(selectUser)).subscribe({
      next: (data) => {
        if (data) {
          this.user = data;
        }
      },
    });
  }
  
  showNewPostModal(template: TemplateRef<any>): void {

    this.newPostModalRef = this.modalService.show(template);

    setTimeout(() => {document.getElementById('content').focus(), 250;
    document.getElementById('image').focus(), 250;
    document.getElementById('video').focus(), 250;
  
    });
  }
  newPostCancelled(): void {
    this.newPostModalRef.hide();
    this.newPostEditor = {};
  }
  addPost(): void {
    
      this.postsClinte.create(this.newPostEditor.content,this.newPostEditor.image as FileParameter,this.newPostEditor.video as FileParameter,this.user.id)
      .subscribe( error => console.error(error))
      this.newPostEditor.content={};
      this.newPostCancelled();
    
  }
}
