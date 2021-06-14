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


export var ACCESS_TOKEN_KEY = 'currentUser';

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
				localStorage.setItem(ACCESS_TOKEN_KEY, token.token);
            }));
	}
	
	isAuthenticated():boolean{
		var token = localStorage.getItem(ACCESS_TOKEN_KEY);
		return token != null && !this.JwtHelper.isTokenExpired(token);
	}

	logout(): void{
		localStorage.removeItem(ACCESS_TOKEN_KEY);
		this.router.navigate(['login']);
	}
}