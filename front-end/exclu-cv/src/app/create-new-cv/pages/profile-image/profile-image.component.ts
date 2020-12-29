import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-profile-image',
  templateUrl: './profile-image.component.html',
  styleUrls: ['./profile-image.component.scss'],
})
export class ProfileImageComponent implements OnInit {
  profileImage: any;
  userDetails: any;

  @Output() public onUploadFinished = new EventEmitter();

  constructor(private http: HttpClient, private service: UserService) {}

  ngOnInit(): void {
    // this.service.getUserProfile().subscribe(
    //   (response) => {
    //     this.userDetails = response;
    //     this.profileImage = `http://localhost:52856/${this.userDetails.profileImage}`;
    //   },
    //   (error) => {
    //     console.log(error);
    //   }
    // );
  }

  public uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }

    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    console.log(fileToUpload.name);

    this.http
      .post('http://localhost:52856/api/upload/profileImage', formData, {
        reportProgress: true,
        observe: 'events',
      })
      .subscribe((event) => {
        console.log(event);
        if (event.type === HttpEventType.UploadProgress) {
        } else if (event.type === HttpEventType.Response) {
          this.onUploadFinished.emit(event.body);
        }
      });
    // window.location.reload();
  };
}
