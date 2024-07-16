//componente que gestiona el inicio de sesión de un usuario

import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';

import { AuthApiService } from '../../services/authServices';
import { LoginModel } from '../../interfaces/user-token.interface';

@Component({
  selector: 'app-auth-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginAuthComponent {
  formLogin: FormGroup;
  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';
  durationInSeconds = 5;

  constructor(
    private fb:FormBuilder,
    private authService: AuthApiService,
    private router: Router,
    private _snackBar: MatSnackBar,
  ){
    //creamos el formulario
    this.formLogin = this.fb.group({
      username: ['',Validators.required],
      password: ['',Validators.required],
    });
  }

  //metodo que muestra un alerta
  mostrarAlerta(message: string, action: string) {
    this._snackBar.open(message, action,{
        horizontalPosition: this.horizontalPosition,
        verticalPosition: this.verticalPosition,
        duration: this.durationInSeconds * 1000
      });
  }

  //metodo que realiza el inicio de sesion
  loginUser():void{

    const loginModel :LoginModel={
      username: this.formLogin.value.username,
      password: this.formLogin.value.password,
    };

    this.authService.login(loginModel.username, loginModel.password).subscribe({
      next:(data)=>{
        this.mostrarAlerta('El usuario inicio sesión','Ok');
        this.router.navigate(['/']);
      },
      error:(e)=>{
        this.mostrarAlerta('No se pudo iniciar sesión','Error');
      }
    });

  }

}
