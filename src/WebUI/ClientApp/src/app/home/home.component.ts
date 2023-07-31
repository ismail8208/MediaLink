import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { IUserDto } from '../web-api-client';
import { Store } from '@ngrx/store';
import { setUser } from '../stateManagement/user.actions';
import { TokenService } from '../sheard/tokenService';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls:['./home.component.css']
})
export class HomeComponent implements OnInit {

  user: IUserDto;
  userRole: any;
  token: string = "";
  isError: boolean = false;

  constructor(private authorizeService: AuthorizeService, private store: Store, private tokenService: TokenService)
  {
  }

  ngOnInit(): void {


    this.authorizeService.getUserInfo().subscribe({
      next: data => {
        this.user = data;
        if(data.profileImage)
        {
          this.user.profileImage = `https://localhost:44447/api/Images/${data.profileImage}`;
        } else {
        this.user.profileImage = 'https://localhost:44447/api/Images/f08c0eb9-cdde-471c-af59-a83005ea784f_Screenshot_٢٠٢٠-٠٩-٢٠-١٦-٤٤-١١.png';
        }
        this.store.dispatch(setUser({ user: this.user }));
      } 
    });

  }

  
}
