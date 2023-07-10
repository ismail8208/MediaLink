import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorizeGuard } from '../api-authorization/authorize.guard';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { TodoComponent } from './todo/todo.component';
import { TokenComponent } from './token/token.component';
import { ProfileComponent } from './profile/profile.component';
import { AddSkillComponent } from './profile/skills/addSkill/add-skill.component';

export const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: '#openModal', component: AddSkillComponent },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthorizeGuard] },
  { path: 'todo', component: TodoComponent, canActivate: [AuthorizeGuard] },
  { path: 'token', component: TokenComponent, canActivate: [AuthorizeGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
