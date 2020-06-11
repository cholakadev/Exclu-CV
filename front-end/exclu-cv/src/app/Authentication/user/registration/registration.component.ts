import { RouterModule, ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  constructor(
    public service: UserService,
    private toastr: ToastrService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.service.formModel.reset();
  }

  onSubmit() {
    this.service.register().subscribe(
      (response: any) => {
        if (response.succeeded) {
          this.service.formModel.reset();
          this.toastr.success('New user created!', 'Registration successful');
          setTimeout(() => { this.router.navigate(['/user/login']) }, 2000);
        } else {
          response.errors.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserName':
                this.toastr.error('Username is already taken!', 'Registration failed');
                //Username is already taken.
                break;

              default:
                //Registration failed.
                this.toastr.error(element.description, 'Registration failed');
                break;
            }
          });
        }
      },
      error => {
        console.log(error);
      })
  }

}
