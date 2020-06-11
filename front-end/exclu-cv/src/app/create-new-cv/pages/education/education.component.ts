import { Component, OnInit } from '@angular/core';
import { FormArray, FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { GlobalConstants } from 'src/environments/environment';
import { ToastrService } from 'ngx-toastr';
import { MomentDateAdapter, MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatDatepicker } from '@angular/material/datepicker';
import * as _moment from 'moment';
import { default as _rollupMoment, Moment } from 'moment';

@Component({
  selector: 'app-education',
  templateUrl: './education.component.html',
  styleUrls: ['./education.component.scss'],
})

export class EducationComponent implements OnInit {

  educationForm: FormGroup;
  submitted = false;


  constructor(
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
    this.educationForm = this.formBuilder.group({
      start_date: ['', Validators.required],
      end_date: ['', Validators.required],
      institution: ['', Validators.required],
      course: ['', Validators.required],
    });
  }

  get f() { return this.educationForm.controls; }

  onSubmit(data): any {
    this.submitted = true;
    if (this.educationForm.invalid) {
      return;
    }

    GlobalConstants.cv['educations'] = data;
    localStorage.setItem("cv", JSON.stringify(GlobalConstants.cv))
    this.toastr.success('Successfully saved!');
  }

  get educationForms() {
    return this.educationForm.get('educationForms') as FormArray;
  }

  addNewEducationForm() {
    // this.educationForms.push(this.formBuilder.control(''));
    let cv = localStorage.getItem("cv");
    console.log(cv);
  }

}
