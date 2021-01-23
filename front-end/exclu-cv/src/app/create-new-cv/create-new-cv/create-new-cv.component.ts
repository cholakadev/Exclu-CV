import { Router } from '@angular/router';
import { ICv } from 'src/interfaces/cv';
import { Component, HostListener, ViewChild, OnInit } from '@angular/core';
import { ExclucvServiceService } from 'src/services/exclucv-service.service';
import { ToastrService } from 'ngx-toastr';
import { MatTabGroup } from '@angular/material/tabs';

@Component({
  selector: 'app-create-new-cv',
  templateUrl: './create-new-cv.component.html',
  styleUrls: ['./create-new-cv.component.scss'],
})
export class CreateNewCvComponent implements OnInit {
  @ViewChild('templates', { static: false }) templateTab: MatTabGroup;

  @HostListener('click', ['$event.target'])
  clickSelector() {
    this.setTabIndex(this.templateTab);
  }

  cv: ICv;

  constructor(
    private _exclucvService: ExclucvServiceService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngAfterViewInit() {
    let tabId = parseInt(localStorage.getItem('tab_id'));
    console.log('tab_id' + tabId);
    this.templateTab.selectedIndex = tabId;
  }

  ngOnInit() {}

  private setTabIndex(tabGroup: MatTabGroup) {
    if (!tabGroup || !(tabGroup instanceof MatTabGroup)) return;
    localStorage.setItem('tab_id', tabGroup.selectedIndex.toString());
  }

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
        this.router.navigate(['/home/all']);
      }, 1000);
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
    var matches = document.querySelectorAll('a');
    matches.forEach((element) => {
      element.classList.remove('active');
    });
  }
}
