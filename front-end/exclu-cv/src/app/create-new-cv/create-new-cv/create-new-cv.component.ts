import { Router } from '@angular/router';
import { ICv } from 'src/interfaces/cv';
import { Component } from '@angular/core';
import { ExclucvServiceService } from 'src/services/exclucv-service.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create-new-cv',
  templateUrl: './create-new-cv.component.html',
  styleUrls: ['./create-new-cv.component.scss']
})
export class CreateNewCvComponent {

  cv: ICv;

  constructor(
    private _exclucvService: ExclucvServiceService,
    private router: Router,
    private toastr: ToastrService,
  ) { }

  onClick(event) {
    var target = event.target || event.srcElement || event.currentTarget;
    var idAtr = target.attributes.id;
    var value = idAtr.nodeValue;
    this.changeActiveClass(value);
  }

  onCreate() {
    let cv: ICv = JSON.parse(localStorage.getItem('cv'));
    this.create(cv);
    if (cv) {
      localStorage.removeItem('cv');
      this.toastr.success('New CV Created!');
      setTimeout(() => {
        this.router.navigate(["/home/all"])
      }
        , 1000);
    }
  }

  create(data: ICv) {
    if (data) {
      this._exclucvService.createCv(data).subscribe((response) => {
        this.cv = response;
      });
    } else {
      this.toastr.error('Please fill the information properly!');
      return false;
    }
  }

  changeActiveClass(id: string) {
    this.removeActiveClass();
    let elem = document.getElementById(id).classList.add('active');
  }

  removeActiveClass() {
    var matches = document.querySelectorAll("a");
    matches.forEach(element => {
      element.classList.remove('active');
    });
  }

}
