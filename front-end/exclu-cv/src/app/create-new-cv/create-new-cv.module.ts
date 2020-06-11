import { AppModule } from './../app.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreateNewCvRoutingModule } from './create-new-cv-routing.module';
import { MainComponent } from './pages/main/main.component';
import { SkillsComponent } from './pages/skills/skills.component';
import { EducationComponent } from './pages/education/education.component';
import { ExperienceComponent } from './pages/experience/experience.component';
import { CertificatesComponent } from './pages/certificates/certificates.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CreateNewCvComponent } from './create-new-cv/create-new-cv.component';
import { MatButtonModule } from '@angular/material/button';
import { ProfileImageComponent } from './pages/profile-image/profile-image.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule, MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatTabsModule } from '@angular/material/tabs';


@NgModule({
  declarations: [CreateNewCvComponent, MainComponent, SkillsComponent, EducationComponent, ExperienceComponent, CertificatesComponent, ProfileImageComponent],
  imports: [
    CommonModule,
    CreateNewCvRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatFormFieldModule,
    MatInputModule,
    MatOptionModule,
    MatSelectModule,
    MatTabsModule,
  ]
})
export class CreateNewCvModule { }
