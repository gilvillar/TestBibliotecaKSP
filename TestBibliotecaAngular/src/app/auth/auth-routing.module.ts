import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginPageComponent } from './pages/login-page/login-page.component';
import { RegisterPageComponent } from './pages/register-page/register-page.component';

//asignamos las rutas del modulo de autenticacion
// localhost:4200/auth/
const routes: Routes = [
  { path: '', component: LoginPageComponent }, //pagina login
  { path: 'register', component: RegisterPageComponent }, //pagina registrar usuario
];

@NgModule({
  imports: [ RouterModule.forChild( routes ) ],
  exports: [ RouterModule ],
})
export class AuthRoutingModule { }
