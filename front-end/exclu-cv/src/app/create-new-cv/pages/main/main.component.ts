import { GlobalConstants } from './../../../../environments/environment';
import { ExclucvServiceService } from '../../../../services/exclucv-service.service';
import {
  IDepartment,
  ILevel,
  IMainInformation,
} from './../../../../interfaces/main';
import { Component, OnInit, ViewChild, ElementRef, Input } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss'],
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
    private service: UserService
  ) {}

  ngOnInit(): void {
    this.mainInformationForm = this.formBuilder.group({
      FirstName: ['', Validators.required],
      MiddleName: [''],
      LastName: ['', Validators.required],
      Country: ['', [Validators.required]],
      Town: ['', Validators.required],
      MobileNumber: ['', Validators.required],
      PostalCode: ['', Validators.required],
      Summary: ['', Validators.required],
    });

    this._exclucvService.getAllDepartments().subscribe((response) => {
      this.departments = response;
    });

    this._exclucvService.getAllLevels().subscribe((response) => {
      this.levels = response;
    });
  }

  get f() {
    return this.mainInformationForm.controls;
  }

  onSubmit(data): any {
    this.submitted = true;
    if (this.mainInformationForm.invalid) {
      return;
    }

    GlobalConstants.cv['main_information'] = data;
    localStorage.setItem('cv', JSON.stringify(GlobalConstants.cv));
    this.toastr.success('Successfully saved!');
  }
}
