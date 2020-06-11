import { Router } from '@angular/router';
import { GlobalConstants } from './../../../../environments/environment';
import { ExclucvServiceService } from '../../../../services/exclucv-service.service';
import { IDepartment, ILevel, IMainInformation } from './../../../../interfaces/main';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  mainInformationForm: FormGroup;
  submitted = false;

  departments: IDepartment[];
  levels: ILevel[];
  main: IMainInformation;

  @ViewChild('content') content: ElementRef;

  constructor(
    private _exclucvService: ExclucvServiceService,
    private toastr: ToastrService,
    private formBuilder: FormBuilder,
    private service: UserService,
  ) { }

  ngOnInit(): void {

    this.mainInformationForm = this.formBuilder.group({
      first_name: ['', Validators.required],
      middle_name: ['', Validators.required],
      last_name: ['', Validators.required],
      email_address: ['', [Validators.required, Validators.email]],
      position: ['', Validators.required],
      department: ['', Validators.required],
      level: ['', Validators.required],
      location: ['', Validators.required],
      summary: ['', Validators.required],
    });

    this._exclucvService.getAllDepartments().subscribe((response => {
      this.departments = response;
    }));

    this._exclucvService.getAllLevels().subscribe((response => {
      this.levels = response;
    }));
  }

  get f() { return this.mainInformationForm.controls; }

  onSubmit(data): any {
    this.submitted = true;
    if (this.mainInformationForm.invalid) {
      return;
    }

    GlobalConstants.cv['main_information'] = data;
    localStorage.setItem("cv", JSON.stringify(GlobalConstants.cv))
    this.toastr.success('Successfully saved!');
  }

}

