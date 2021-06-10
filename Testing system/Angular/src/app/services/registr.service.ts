import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class RegistrService{
    constructor(private http:HttpClient){}

    registration(firstName:string, lastName:string, email:string, password:string, confirmPassword:string){
        return this.http.post<any>(`${environment.apiUrl}api/login/registration`, { firstName, lastName, email, password, confirmPassword });
    }
}