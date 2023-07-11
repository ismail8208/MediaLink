import { Component, Output,EventEmitter, Input } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CommentsClient, CreateCommentCommand } from 'src/app/web-api-client';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent {
  @Input() postId: number;
  @Output() close: EventEmitter<boolean> = new EventEmitter<boolean>();
  comment:{
    content: "string",
    postId: 5,
    userId:5,
  }
  
  constructor(private commentClient: CommentsClient){}
    closed():void{
      this.close.emit(true);

    }
    sendFormdata(form: NgForm):void{
      console.log(form.value.content.length)
    if(form.value.content.length>0){
    this.comment.content=form.value.content;
    this.commentClient.create(this.comment as CreateCommentCommand).subscribe(error => console.error(error));
    console.log("comment creted");
    this.close.emit(true);
    }

  }
  
}