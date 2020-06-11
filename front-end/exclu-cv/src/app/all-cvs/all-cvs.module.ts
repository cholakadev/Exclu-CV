import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';

import { AllCvsRoutingModule } from './all-cvs-routing.module';
import { PreviewComponent } from './preview/preview.component';


@NgModule({
  declarations: [PreviewComponent],
  imports: [
    CommonModule,
    BrowserModule,
    AllCvsRoutingModule,
  ],
  providers: [
    DatePipe
  ]
})
export class AllCvsModule { }
