import { Component, OnInit, Output, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatTabGroup } from '@angular/material/tabs';
import { Router } from '@angular/router';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-auth-dialog',
  templateUrl: './auth-dialog.component.html',
  styleUrls: ['./auth-dialog.component.scss'],
})
export class AuthDialogComponent implements OnInit {
  @Output() registerModel;
  @ViewChild('tabs', { static: false }) loginTab: MatTabGroup;
  auth: any;

  selected = -1;
  loginForm: FormGroup;
  registerForm: FormGroup;
  perspectives = [
    {
      index: 0,
      perspectiveType: 'Employer',
    },
    {
      index: 1,
      perspectiveType: 'Employee',
    },
  ];

  constructor(
    private router: Router,
    private service: UserService,
    private dialog: MatDialogRef<AuthDialogComponent>
  ) {}

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl(''),
      password: new FormControl(''),
    });

    this.registerForm = new FormGroup({
      email: new FormControl(''),
      password: new FormControl(''),
    });
  }

  onSubmitLoginForm() {
    this.service.login(this.loginForm.value).subscribe((response) => {
      console.log(response);
      this.auth = response;
      localStorage.setItem('token', this.auth.token);
      this.dialog.close();
      this.router.navigate(['/home/create']);
    });
  }

  onSubmitRegisterForm() {
    this.registerModel = {
      email: this.registerForm.value.email,
      password: this.registerForm.value.password,
    };

    this.service.register(this.registerModel).subscribe((response) => {
      console.log(response);
      setTimeout(() => {
        this.goToNextTabIndex(this.loginTab);
      }, 500);
      this.registerForm.reset();
    });
  }

  private goToNextTabIndex(tabGroup: MatTabGroup) {
    if (!tabGroup || !(tabGroup instanceof MatTabGroup)) return;

    const tabCount = tabGroup._tabs.length;
    tabGroup.selectedIndex = (tabGroup.selectedIndex + 1) % tabCount;
  }
}
