import { Component, OnInit } from '@angular/core';
import { FormArray, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GlobalConstants } from 'src/environments/environment';
import { ToastrService } from 'ngx-toastr';
import * as _moment from 'moment';
import { default as _rollupMoment } from 'moment';

@Component({
  selector: 'app-education',
  templateUrl: './education.component.html',
  styleUrls: ['./education.component.scss'],
})
export class EducationComponent implements OnInit {
  public educations: FormArray;
  public educationForm: FormGroup;

  submitted = false;

  constructor(private formBuilder: FormBuilder, private toastr: ToastrService) {
    this.educationForm = this.formBuilder.group({
      educations: this.formBuilder.array([]),
    });
  }

  ngOnInit(): void {}

  get educationControls() {
    return this.educationForm.get('educations')['controls'];
  }

  createEducation(): FormGroup {
    return this.formBuilder.group({
      start_date: ['', Validators.required],
      end_date: ['', Validators.required],
      institution: ['', Validators.required],
      course: ['', Validators.required],
    });
  }

  addEducation(): void {
    this.educations = this.educationForm.get('educations') as FormArray;
    this.educations.push(this.createEducation());
  }

  removeEducation(i: number) {
    this.educations.removeAt(i);
  }

  logValue() {
    console.log('logValue');
    console.log(this.educations.value);
  }

  onSubmit(data): any {
    this.submitted = true;
    if (this.educationForm.invalid) {
      return;
    }

    console.log(data);
  }

  get educationForms() {
    return this.educationForm.get('educationForms') as FormArray;
  }

  addNewEducationForm() {
    // this.educationForms.push(this.formBuilder.control(''));
    let cv = localStorage.getItem('cv');
    console.log(cv);
  }
}
