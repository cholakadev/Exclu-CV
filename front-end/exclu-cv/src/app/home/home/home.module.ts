import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';


@NgModule({
  declarations: [],
  imports: [
    RouterModule,
    CommonModule,
    HomeRoutingModule,
    MatButtonModule,
  ]
})
export class HomeModule { }
