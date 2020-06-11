import { MatDatepickerModule } from '@angular/material/datepicker';
import { PreviewComponent } from './all-cvs/preview/preview.component';
import { HomeComponent } from './home/home/home.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AllCvsComponent } from './all-cvs/all-cvs/all-cvs.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';
import { RegistrationComponent } from './Authentication/user/registration/registration.component';
import { LoginComponent } from './Authentication/user/login/login.component';
import { UserComponent } from './Authentication/user/user.component';
import { UserService } from 'src/services/user.service';
import { AuthInterceptor } from './Authentication/auth.interceptor';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { CommonModule, DatePipe } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatNativeDateModule } from '@angular/material/core';
import { MatTableModule } from '@angular/material/table';

@NgModule({
  declarations: [
    AppComponent,
    AllCvsComponent,
    RegistrationComponent,
    LoginComponent,
    UserComponent,
    HomeComponent,
    PreviewComponent
  ],
  imports: [
    [ModalModule.forRoot()],
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    DragDropModule,
    CommonModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatTableModule,
  ],
  providers: [
    UserService, {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
