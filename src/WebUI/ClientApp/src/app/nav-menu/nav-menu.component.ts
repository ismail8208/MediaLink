import { Component, OnInit } from '@angular/core';
import { Observable, map } from 'rxjs';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { IUserDto, UsersClient } from '../web-api-client';
import { Store, select } from '@ngrx/store';
import { selectUser } from '../stateManagement/user.selectors';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent implements OnInit {

  public isAuthenticated?: Observable<boolean>;
  user: IUserDto;

  constructor(private authorizeService: AuthorizeService, private usersClient: UsersClient, private store: Store) { }

  ngOnInit() {

    this.isAuthenticated = this.authorizeService.isAuthenticated();

    this.store.pipe(select(selectUser)).subscribe({
      next: (data) => {
        if (data) {
          this.user = data;
        }
      },
    });
  }
  
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
