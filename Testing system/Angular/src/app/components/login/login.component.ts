import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  authService : AuthService;

  constructor(as: AuthService) {
    this.authService = as;
   }

  ngOnInit(): void {
  }

  login(email: string, password: string){
    this.authService.login(email, password)
    .subscribe(res => {},
    error => {
      alert('Невірний логін або пароль!')
    })
  }

}
