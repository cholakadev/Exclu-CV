import { MainComponent } from './pages/main/main.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateNewCvComponent } from './create-new-cv/create-new-cv.component';
import { SkillsComponent } from './pages/skills/skills.component';
import { EducationComponent } from './pages/education/education.component';
import { ExperienceComponent } from './pages/experience/experience.component';
import { CertificatesComponent } from './pages/certificates/certificates.component';


const routes: Routes = [
  {
    path: '',
    component: CreateNewCvComponent,
    children: [
      {
        path: 'main',
        component: MainComponent
      },
      {
        path: 'skills',
        component: SkillsComponent
      },
      {
        path: 'education',
        component: EducationComponent
      },
      {
        path: 'experience',
        component: ExperienceComponent
      },
      {
        path: 'certificates',
        component: CertificatesComponent
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CreateNewCvRoutingModule { }
