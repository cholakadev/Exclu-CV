import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { switchMap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private fb: FormBuilder, private http: HttpClient) {}

  readonly BaseURI = 'http://localhost:52856/api';

  formModel = this.fb.group({
    Email: ['', Validators.email],
    Passwords: this.fb.group(
      {
        Password: ['', [Validators.required, Validators.minLength(4)]],
        ConfirmPassword: ['', Validators.required],
      },
      {
        validator: this.comparePasswords,
      }
    ),
  });

  comparePasswords(fb: FormGroup) {
    let confirmPasswordControl = fb.get('ConfirmPassword');

    if (
      confirmPasswordControl.errors == null ||
      'passwordMismatch' in confirmPasswordControl.errors
    ) {
      if (fb.get('Password').value != confirmPasswordControl.value) {
        confirmPasswordControl.setErrors({
          passwordMismatch: true,
        });
      } else {
        confirmPasswordControl.setErrors(null);
      }
    }
  }

  register(formData) {
    var body = {
      Email: this.formModel.value.Email,
      Password: this.formModel.value.Passwords.Password,
      ConfirmPassword: this.formModel.value.ConfirmPassword,
    };

    return this.http.post(this.BaseURI + '/user/registration', formData);
  }

  login(formData) {
    return this.http.post(this.BaseURI + '/user/login', formData);
  }

  getUserProfile() {
    return this.http.get(this.BaseURI + '/user/profile');
  }
}
