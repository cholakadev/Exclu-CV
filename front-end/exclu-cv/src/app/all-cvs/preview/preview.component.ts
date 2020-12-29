import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { ExclucvServiceService } from 'src/services/exclucv-service.service';
import * as jsPDF from 'jspdf';
import html2canvas from 'html2canvas';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-preview',
  templateUrl: './preview.component.html',
  styleUrls: ['./preview.component.scss'],
})
export class PreviewComponent implements OnInit {
  profileImage: any;
  userDetails: any;

  private routeSub: Subscription;

  @ViewChild('content') content: ElementRef;

  private currentCvId: number;

  cv: any;

  constructor(
    private _router: Router,
    private route: ActivatedRoute,
    private _exclucvService: ExclucvServiceService,
    private service: UserService
  ) {}

  ngOnInit(): void {
    this.service.getCurrentUser().subscribe(
      (response) => {
        this.userDetails = response;
        this.profileImage = `http://localhost:52856/${this.userDetails.profileImage}`;
      },
      (error) => {
        console.log(error);
      }
    );

    this.routeSub = this.route.params.subscribe((params) => {
      this.currentCvId = params['id'];
      console.log(this.currentCvId);
    });

    this._exclucvService.getAllCvs().subscribe((response) => {
      response.forEach((element) => {
        if (element.id == this.currentCvId) {
          this.cv = element;
          console.log(this.cv);
        }
      });
    });
  }

  onExportClick() {
    window.print();
    // let data = document.getElementById('element-to-export');
    // html2canvas(data).then(canvas => {
    //   const contentDataURL = canvas.toDataURL('image/png')
    //   let pdf = new jsPDF('l', 'cm', 'a4'); //Generates PDF in landscape mode
    //   pdf.addImage(contentDataURL, 'PNG', 0, 0, 29.7, 21.0);
    //   pdf.save('Filename.pdf');
    // });
  }

  goBack() {
    this._router.navigate(['/home/all']);
  }
}
