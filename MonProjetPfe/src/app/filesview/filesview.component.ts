import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { QrCodeDialogComponent } from '../qr-code-dialog/qr-code-dialog.component';

@Component({
  selector: 'app-filesview',
  templateUrl: './filesview.component.html',
  styleUrls: ['./filesview.component.css']
})
export class FilesviewComponent {
  public pageTitle = 'Welcome to View Files component';
  constructor(private http: HttpClient, private dialog: MatDialog) {
    this.getAllFiles();
  }
  files: any = [];
  getAllFiles() {
    return this.http.get('http://localhost:48608/FileManager')
      .subscribe((result) => {
        this.files = result;
        console.log(result);
      });
  }
  downloadFile(id: number, contentType: string) {
    return this.http.get(`http://localhost:48608/FileManager/${id}`, { responseType: 'blob' })
      .subscribe((result: Blob) => {
        const blob = new Blob([result], { type: contentType }); // you can change the type
        const url = window.URL.createObjectURL(blob);
        window.open(url);
        console.log("Success");
      });
  }
  generateQrcode(file: any) {
    file.qrcode = `http://localhost:48608/FileManager/${file.id}`

    this.dialog.open(QrCodeDialogComponent, {

      data: { qrcode: file.qrcode },
      width: '200',
    })
  }

}
