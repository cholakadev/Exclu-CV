import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AllCvsComponent } from './all-cvs/all-cvs.component';


const routes: Routes = [
  {
    path: '',
    component: AllCvsComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AllCvsRoutingModule { }
