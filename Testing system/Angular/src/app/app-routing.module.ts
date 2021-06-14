import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { TestsComponent } from './components/tests/tests.component';

const routes: Routes = [
	{path: 'login', component: LoginComponent},
	{path: 'tests', component: TestsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
