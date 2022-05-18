import { Component, ContentChild, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Model } from '../Model/Model';
import Swal from 'sweetalert2';
import { IonInput } from '@ionic/angular';
import { AuthService } from '../Services/auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  user?: String;
  personne: any;
  loginForm!: FormGroup;
  //user = new Model();
  constructor(
    private _formBuilder: FormBuilder,
    private router: Router,

  ) {
  }
  /*constructor(private route: Router, private formBui: FormBuilder, private userServ: AuthService, private snackBar: MatSnackBar
  ) { }*/
  ngOnInit(): void {
    this.loginForm = this._formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });

  }
  /*ngOnInit(): void {
    this.loginForm = this.formBui.group(
      {
        email: ['', [Validators.required, Validators.email]],
        password: ['', Validators.required]
      }

    )
  }*/

  login() {
    const { email, password } = this.loginForm.value;

    if (email === 'admin@gmail.com' && password === 'admin123') {
      this.router.navigateByUrl('home')
    }
    else if (email === 'res@gmail.com' && password === 'admin123') {
      this.router.navigateByUrl('homeresponsable')
    }
    else if (email === 'emp@gmail.com' && password === 'admin123') {
      this.router.navigateByUrl('homeemploye')
    }
    else
      Swal.fire('Non connecté', 'Login ou mot de passe incorrecte!', 'error');

  }
  /*
  SingIn() {

    if (this.loginForm.value.email != null && this.loginForm.value.password != null) {
      this.userServ.GetUserByEmail(this.loginForm.value.email).subscribe(
        data => {
          this.personne = data;

          if (this.personne.length != 0) {
            sessionStorage['role'] = this.personne[0].role
            sessionStorage['logedInEmail'] = this.loginForm.value.email



            if (this.personne[0].role === "Admin" && this.personne[0].password === this.loginForm.value.password) {
              sessionStorage['login'] = true
              document.location.href = "/home"


            } else {
              //si l'utilisateur est res

              this.userServ.passwordMatches(this.loginForm.value.email, this.loginForm.value.password).subscribe(
                data => {
                  console.log(data)
                  if (data === true && this.personne[0].role === "Responsable") {
                    sessionStorage['login'] = true
                    sessionStorage['id'] = this.personne[0].id
                    document.location.href = "/homeresponsable"
                  } else {
                    this.snackBar.open("votre mot de passe est incorrecte", "",
                      {
                        duration: 3000,
                        verticalPosition: "bottom"
                      })
                  }
                })


            }

            //si l'email saisie n'existe pas dans la base de données
          } else {
            this.snackBar.open("Votre Compt n'existe pas", "",
              {
                duration: 3000,
                verticalPosition: "bottom"
              })
          }
        })
    }//si les champs sont vide
    else {
      this.snackBar.open("Remplir Tous Les Champs ", "",
        {
          duration: 3000,
          verticalPosition: "bottom"
        },
      )
    }

  }
  logOut(): void {

    this.userServ.signOut().then().catch();



  }*/


  // this.router.navigate(['/home'])
}


