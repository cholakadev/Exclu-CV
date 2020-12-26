import { AuthGuard } from './Authentication/auth.guard';
import { AllCvsComponent } from './all-cvs/all-cvs/all-cvs.component';
import { HomeComponent } from './home/home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomePageComponent } from './Authentication/home-page/home-page.component';
import { PreviewComponent } from './all-cvs/preview/preview.component';


const routes: Routes = [
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    component: HomePageComponent
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
