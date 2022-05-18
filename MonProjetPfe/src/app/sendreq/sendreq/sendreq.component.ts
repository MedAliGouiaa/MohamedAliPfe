import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-sendreq',
  templateUrl: './sendreq.component.html',
  styleUrls: ['./sendreq.component.css']
})
export class SendreqComponent {
  reqForm = new FormGroup({
    typedemande: new FormControl(''),
    description: new FormControl('')
  });

  constructor(private http: HttpClient) {
  }


  sendreq() {
    debugger
    const formData: FormData = new FormData();
    formData.append('typedemande', this.reqForm.value.typedemande);
    formData.append('description', this.reqForm.value.description);
    formData.append('date', this.reqForm.value.date);
    return this.http.post('http://localhost:60982/api/Demandes', formData,
      {
        headers: new HttpHeaders()
      })
      .subscribe(() => alert("Bien reçu"));
  }

}
