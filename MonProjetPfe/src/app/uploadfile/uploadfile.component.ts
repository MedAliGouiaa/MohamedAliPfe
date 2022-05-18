import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-uploadfile',
  templateUrl: './uploadfile.component.html',
  styleUrls: ['./uploadfile.component.css']
})
export class UploadfileComponent {
  public pageTitle = 'Welcome to fileupload component';
  fileForm = new FormGroup({

    description: new FormControl('')
  });
  fileToUpload: any;
  constructor(private http: HttpClient) {
  }

  handleFileInput(e: any) {

    console.log(e?.target?.files[0]);
    this.fileToUpload = e?.target?.files[0];
    console.log(this.fileToUpload);
  }
  saveFileInfo() {
    debugger
    const formData: FormData = new FormData();
    console.log('myFile');
    console.log(this.fileToUpload);

    formData.append('myFile', this.fileToUpload);

    formData.append('description', this.fileForm.value.description);
    return this.http.post('http://localhost:48608/FileManager', formData,
      {
        headers: new HttpHeaders()
      })
      .subscribe(() => alert("File uploaded"));
  }
}

