import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AuthDialogComponent } from '../dialogs/auth-dialog/auth-dialog.component';

@Component({
  selector: 'app-user',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {
  public isUserAuthenticated: boolean = false;

  constructor(public dialog: MatDialog) { }

  ngOnInit(): void {
    let token = localStorage.getItem('token');
    console.log(token);
    if (token) {
      this.isUserAuthenticated = !this.isUserAuthenticated;
      console.log(this.isUserAuthenticated);
      document.getElementById('trial').style.display = "none";
      document.getElementById('try-free').style.display = "none";
    }
  }

  getUrl() {
    return "url('../../../assets/img/auth.jpg')";
  }

  openDialog() {
    this.dialog.open(AuthDialogComponent, {
      height: '500px',
      width: '600px',
    });
  }

  logOut() {
    localStorage.removeItem('token');
    window.location.reload();
    // this.router.navigate(['home']);
  }

}
