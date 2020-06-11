import { Component, OnInit, TemplateRef } from '@angular/core';
import { ExclucvServiceService } from 'src/services/exclucv-service.service';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H' },
  { position: 2, name: 'Helium', weight: 4.0026, symbol: 'He' },
  { position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li' },
  { position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be' },
  { position: 5, name: 'Boron', weight: 10.811, symbol: 'B' },
  { position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C' },
  { position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N' },
  { position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O' },
  { position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F' },
  { position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne' },
];

@Component({
  selector: 'app-all-cvs',
  templateUrl: './all-cvs.component.html',
  styleUrls: ['./all-cvs.component.scss']
})
export class AllCvsComponent implements OnInit {

  cvs: any;
  currentCv: any;
  modalRef: BsModalRef;

  displayedColumns: string[] = ['position', 'name', 'symbol'];
  dataSource = this.cvs;

  constructor(
    private _exclucvService: ExclucvServiceService,
    private _router: Router,
    private modalService: BsModalService,
  ) { }

  ngOnInit(): void {
    this._exclucvService.getAllCvs().subscribe((response => {
      this.cvs = response;
    }));
  }

  deleteCv(id: number) {
    this._exclucvService.deleteCv(id).subscribe((response) => {
      this._exclucvService.getAllCvs().subscribe(resp => {
        this.cvs = resp;
        this.reloadComponent();
      })
    })
  }

  preview(id: number) {

    this._router.navigate([`/preview/${id}`])

    this.cvs.forEach(element => {
      if (element.id == id) {
        console.log(element);
        this.currentCv = element;
      }
    });
  }

  reloadComponent() {
    this._router.routeReuseStrategy.shouldReuseRoute = () => false;
    this._router.onSameUrlNavigation = 'reload';
    this._router.navigate(['/home/all']);
  }

}
