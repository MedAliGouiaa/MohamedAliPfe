import { Component, OnInit, Output, EventEmitter, ChangeDetectorRef } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Model } from 'src/app/Model/Model';
import { ServicesService } from 'src/app/Services/services.service';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css'],
})
export class AddComponent implements OnInit {
  NewUser: FormGroup = new FormGroup({
    Nom: new FormControl(''),
    Prenom: new FormControl(''),
    Email: new FormControl(''),
    Motpasse: new FormControl(''),
    Role: new FormControl(''),

  });
  constructor(
    private fb: FormBuilder,
    private ServicesService: ServicesService,
    public dialog: MatDialog,
    private ref: ChangeDetectorRef
  ) { }
  User: any;
  ngOnInit() {
    this.NewUser = this.fb.group({
      Nom: ['', Validators.required],
      Prenom: ['', Validators.required],
      Email: ['', Validators.required],
      Motpasse: ['', Validators.required],
      Role: ['', Validators.required],

    });
    // this.ref.detectChanges();

  }
  AddNewUser(FormData: any) {
    this.ServicesService.AddNewUser(FormData.value).subscribe(
      (Response: any) => {
        this.User = Response;
        console.log(this.User.Id);
      },
      (error: any) => {
        console.log(error);
      }
    );
    console.log(this.NewUser.value);
    this.dialog.closeAll();
    this.refresh();
  }
  refresh() {
    window.location.reload();
  }
}
