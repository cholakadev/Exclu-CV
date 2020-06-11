import { ISkillLevel } from './../../../../interfaces/skills';
import { GlobalConstants } from './../../../../environments/environment';
import { ExclucvServiceService } from 'src/services/exclucv-service.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-skills',
  templateUrl: './skills.component.html',
  styleUrls: ['./skills.component.scss']
})
export class SkillsComponent implements OnInit {

  levels: ISkillLevel[];

  isSubmitted = false;

  localStorageSkills: any;

  skillsForm: FormGroup;

  constructor(
    private exclucvService: ExclucvServiceService,
    private toastr: ToastrService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.skillsForm = this.formBuilder.group({});

    this.exclucvService.getSkillsLevel().subscribe((response => {
      this.levels = response;
    }));
  }

  onSubmit(data): any {
    this.isSubmitted = true;

    GlobalConstants.cv['skills'].push(data);

    console.log(data);

    this.localStorageSkills = GlobalConstants.cv['skills'];

    localStorage.setItem("cv", JSON.stringify(GlobalConstants.cv))
    this.toastr.success('Successfully saved!');
  }
}
