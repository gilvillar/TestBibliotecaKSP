import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { LayoutPageAuthComponent } from './pages/layout-page/layout-page.component';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { RegisterPageComponent } from './pages/register-page/register-page.component';
import { MaterialModule } from '../material/material.module';
import { BooksRoutingModule } from '../Books/books-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LoginAuthComponent } from './components/login/login.component';
import { RegisterAuthComponent } from './components/register/register.component';


@NgModule({
  declarations: [
    LayoutPageAuthComponent,
    LoginPageComponent,
    RegisterPageComponent,
    LoginAuthComponent,
    RegisterAuthComponent,
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    BooksRoutingModule,
    HttpClientModule,
  ],
  exports:[
    LayoutPageAuthComponent,
    LoginAuthComponent
  ]
})
export class AuthModule { }
