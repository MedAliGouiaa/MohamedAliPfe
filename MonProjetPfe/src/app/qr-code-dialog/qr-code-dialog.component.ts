import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-qr-code-dialog',
  templateUrl: './qr-code-dialog.component.html',
  styleUrls: ['./qr-code-dialog.component.css']
})
export class QrCodeDialogComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<QrCodeDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {

  }
  ngAfterViewInit(): void {
    setTimeout(() => {
      const img = (document.querySelector('.qrcode')?.firstChild as HTMLElement).getAttribute('src')

    })
  }
  close() {
    this.dialogRef.close()
  }


}
