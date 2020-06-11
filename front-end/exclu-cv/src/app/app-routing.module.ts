import { AuthGuard } from './Authentication/auth.guard';
import { AllCvsComponent } from './all-cvs/all-cvs/all-cvs.component';
import { HomeComponent } from './home/home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './Authentication/user/login/login.component';
import { RegistrationComponent } from './Authentication/user/registration/registration.component';
import { UserComponent } from './Authentication/user/user.component';
import { CreateNewCvComponent } from './create-new-cv/create-new-cv/create-new-cv.component';
import { PreviewComponent } from './all-cvs/preview/preview.component';


const routes: Routes = [
  {
    path: '',
    redirectTo: '/user/registration',
    pathMatch: 'full'
  },
  {
    path: 'user',
    component: UserComponent,
    children: [
      {
        path: 'registration',
        component: RegistrationComponent
      },
      {
        path: 'login',
        component: LoginComponent
      }
    ]
  },
  {
    path: 'home',
    loadChildren: () => import('./home/home/home.module').then((m) => m.HomeModule),
    canActivate: [
      AuthGuard
    ]
  },
  {
    path: 'preview/:id',
    component: PreviewComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
