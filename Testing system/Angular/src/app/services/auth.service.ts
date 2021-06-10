import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

import { Token } from 'src/app/models/token';
import { SYSTEM_API_URL } from '../app-injection-token';


export var ACCESS_TOKEN_KEY = '';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
  	private http: HttpClient,
  	@Inject(SYSTEM_API_URL) private apiUrl: string,
  	private JwtHelper: JwtHelperService,
  	private router: Router
  	) { }

	login(email: string, password: string):Observable<Token>{
		
		return this.http.post<Token>(`${environment.apiUrl}api/login/login`, { email, password })
            .pipe(tap(token => {
				localStorage.setItem('currentUser', token.token);
				console.log(localStorage.getItem('currentUser'));
            }));
	}
	
	isAuthenticated():boolean{
		var token = localStorage.getItem('currentUser');
		return token != null;
	}

	logout(): void{
		localStorage.removeItem('currentUser');
		this.router.navigate(['']);
	}
}