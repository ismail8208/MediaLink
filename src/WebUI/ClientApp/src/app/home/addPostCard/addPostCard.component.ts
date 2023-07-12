
import { Component, OnInit } from '@angular/core';
import {IUserDto} from '../../web-api-client';
import { Store, select } from '@ngrx/store';
import { selectUser } from 'src/app/stateManagement/user.selectors';

@Component({
  selector: 'app-addPostCard',
  templateUrl: './addPostCard.component.html',
  styleUrls: ['./addPostCard.component.css']
})

export class AddPostCardComponent implements OnInit {
 
  user: IUserDto;
  constructor(private store: Store){}
  ngOnInit(): void {
    
    this.store.pipe(select(selectUser)).subscribe({
      next: (data) => {
        if (data) {
          this.user = data;
        }
      },
    });
  }
}
