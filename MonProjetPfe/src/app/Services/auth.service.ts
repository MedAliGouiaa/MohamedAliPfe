import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    constructor(
        private http: HttpClient
    ) { }

    /*login(Email: string, Motpasse: string) {
        return this.http.post('http://localhost:60982/api/Users', { Email, Motpasse })
    }*/
}
