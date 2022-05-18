import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Model } from 'src/app/Model/Model';
import { ServicesService } from 'src/app/Services/services.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
})
export class EditComponent implements OnInit {
  user = new Model();
  UpdateUser: any;
  NewUser: FormGroup = new FormGroup({
    nom: new FormControl(''),
    prenom: new FormControl(''),
    email: new FormControl(''),
    motpasse: new FormControl(''),
    role: new FormControl(''),

  });
  constructor(
    @Inject(MAT_DIALOG_DATA) public User: Model,
    private fb: FormBuilder,
    private ServicesService: ServicesService,
    public dialog: MatDialog,
    private ref: ChangeDetectorRef

  ) { }

  ngOnInit(): void {
    this.ServicesService.GetAllUsers;
    this.ServicesService.GetUserById(this.User.id).subscribe(
      (result: any) => {
        this.user = result;
        this.user.id = result.id;
        // this.ref.detectChanges();
        console.log(this.user);
      }
    );
    this.UpdateUser = this.fb.group({
      nom: ['', Validators.required],
      prenom: ['', Validators.required],
      email: ['', Validators.required],
      motpasse: ['', Validators.required],
      role: ['', Validators.required],

    });
    this.UpdateUser.patchValue(this.User);
  }
  EditUser(FormData: any) {

    this.ServicesService.EditUserById(
      this.user.id,
      FormData.value
    ).subscribe((UpdatedUser) => {
      console.log(UpdatedUser);
      // this.ref.detectChanges();

    });
    this.dialog.closeAll();
    this.refresh();
  }
  refresh() {
    window.location.reload();
  }

}
