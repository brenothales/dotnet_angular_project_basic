import { Routes } from '@angular/router';

import { MessagesComponent } from './messages/messages.component';
import { MemberListComponent } from './memberList/memberList.component';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './Lists/Lists.component';

export const appRoutes : Routes = [

  { path: '', component: HomeComponent           },
  { path: 'members', component: MemberListComponent  },
  { path: 'messages', component: MessagesComponent   },
  { path: 'lists', component: ListsComponent         },
  { path: '**', redirectTo: '/home', pathMatch: 'full'}

];
