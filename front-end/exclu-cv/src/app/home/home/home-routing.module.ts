import { AllCvsComponent } from './../../all-cvs/all-cvs/all-cvs.component';
import { HomeComponent } from './home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateNewCvComponent } from 'src/app/create-new-cv/create-new-cv/create-new-cv.component';
import { CreateNewCvModule } from 'src/app/create-new-cv/create-new-cv.module';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
      {
        path: 'create',
        loadChildren: () => import('../../create-new-cv/create-new-cv.module').then((m) => m.CreateNewCvModule)
      },
      {
        path: 'all',
        component: AllCvsComponent
      },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
