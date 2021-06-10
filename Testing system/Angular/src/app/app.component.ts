import { Component, OnInit } from '@angular/core';

import { AuthService } from './services/auth.service';
import { RegistrService } from './services/registr.service';
import { Test } from './models/test';
import { TestsService } from './services/tests.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  tests: Test[] | undefined;
  
  authService : AuthService;
  registrService: RegistrService;
  testsService: TestsService;

  showAuthorization:boolean = true;
  showRegistration:boolean = false;

  constructor(as: AuthService, rs: RegistrService, ts: TestsService){
    this.authService = as;
    this.registrService = rs;
    this.testsService = ts;
  }
  ngOnInit() {
     
  }
  Authorization(){
    this.showAuthorization = true;
    this.showRegistration = false;
  }
  Registration(){
    this.showRegistration = true;
    this.showAuthorization = false;
  }

  public get isLoggedIn() : boolean {
    if(this.authService.isAuthenticated()){
      this.showAuthorization = false;
      return true;
    }
    return false;
  }

  login(email: string, password: string){
    this.authService.login(email, password)
    .subscribe(res => {},
    error => {
      alert('Невірний логін або пароль!')
    })
  }
  logout(){
    this.authService.logout();
  }
  registration(firstName:string, lastName:string, email:string, password:string, confirmPassword:string){
    this.registrService.registration(firstName, lastName, email, password, confirmPassword)
    .subscribe(res => {},
      error => {
        alert('Некоректно введені дані!')
      })
  }
}
