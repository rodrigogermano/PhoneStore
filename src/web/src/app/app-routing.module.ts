import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginCallbackComponent } from './pages/login-callback/login-callback.component';
import { UnauthorizedComponent } from './pages/unauthorized/unauthorized.component';
import { AuthGuard } from 'src/auth/auth-guard';
import { HomeComponent } from './pages/home/home.component';


const routes: Routes = [
  { 
    path: '', 
    //loadChildren: () => import('./pages/home/home.module').then(m => m.HomeModule) 
    component:HomeComponent
  },
  { 
    path: 'login-callback', 
    component:LoginCallbackComponent
  },
  { 
    path: 'unauthorized', 
    component:UnauthorizedComponent
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  providers: [
    AuthGuard
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
