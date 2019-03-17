import { Routes } from '@angular/router';

import { AuthGuard } from './_guards/auth.guard';
import { MessagesComponent } from './messages/messages.component';
import { MemberListComponent } from './memberList/memberList.component';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './Lists/Lists.component';

export const appRoutes: Routes = [

  { path: 'home', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'members', component: MemberListComponent},
      { path: 'messages', component: MessagesComponent},
      { path: 'lists', component: ListsComponent},
    ]
  },
  { path: '**', redirectTo: 'home', pathMatch: 'full'}

];
