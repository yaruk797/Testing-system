import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { HttpClientModule } from '@angular/common/http'
import { JwtModule } from '@auth0/angular-jwt'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SYSTEM_API_URL } from './app-injection-token';
import { environment } from 'src/environments/environment';
import { ACCESS_TOKEN_KEY } from './services/auth.service';
import { TestsComponent } from './components/tests/tests.component';
import { LoginComponent } from './components/login/login.component'


export function tokenGetter(){
  return localStorage.getItem('currentUser');
}

@NgModule({
  declarations: [
    AppComponent,
    TestsComponent,
    LoginComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter,
        allowedDomains: ['localhost:44320']
      }
    })
    
  ],
  providers: [{
    provide: SYSTEM_API_URL,
    useValue: environment.apiUrl
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
