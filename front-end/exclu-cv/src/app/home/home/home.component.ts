import { UserService } from 'src/services/user.service';
import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  navbarOpen = false;

  modalRef: BsModalRef;

  userDetails: any;

  constructor(private router: Router, private service: UserService) {}

  ngOnInit(): void {
    this.service.getCurrentUser().subscribe(
      (response) => {
        this.userDetails = response;
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  logOut() {
    localStorage.removeItem('token');
    localStorage.removeItem('cv');
    this.router.navigate(['/home']);
  }
}
