import { Component, OnInit } from '@angular/core';

import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  authService : AuthService;

  constructor(as: AuthService){
    this.authService = as;
  }
  ngOnInit() { }

  public get isLoggedIn() : boolean {
    return this.authService.isAuthenticated();
  }

  logout(){
    this.authService.logout();
  }
}
