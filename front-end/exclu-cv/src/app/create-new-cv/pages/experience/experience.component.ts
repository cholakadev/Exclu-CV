import { IWorkExperience } from './../../../../interfaces/work-experience';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { GlobalConstants } from 'src/environments/environment';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-experience',
  templateUrl: './experience.component.html',
  styleUrls: ['./experience.component.scss']
})

export class ExperienceComponent implements OnInit {

  experienceForm: FormGroup;

  isSubmitted = false;

  localStorageSkills: any[];

  constructor(
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
    this.experienceForm = this.formBuilder.group({
      start_date: ['', Validators.required],
      end_date: ['', Validators.required],
      company: ['', Validators.required],
      position: ['', Validators.required],
      project: ['', Validators.required],
      skills: ['', Validators.required],
    });
  }

  get f() { return this.experienceForm.controls; }

  onSubmit(data): IWorkExperience {
    this.isSubmitted = true;
    if (this.experienceForm.invalid) {
      return;
    }

    GlobalConstants.cv['work_experiences'] = data;
    localStorage.setItem("cv", JSON.stringify(GlobalConstants.cv))
    this.toastr.success('Successfully saved!');
  }

  onAdd() {
    if (typeof (localStorage) !== undefined) {
      let localInformation: any = localStorage.getItem("experience");

      let myString = JSON.stringify(localInformation.company);

      console.log(myString);
    }
  }

}
