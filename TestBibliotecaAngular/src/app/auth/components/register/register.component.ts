//componente que realiza el registro de un nuevo usuario

import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

import { RegisterModel } from '../../interfaces/register-model.interface';
import { AuthApiService } from '../../services/authServices';

@Component({
  selector: 'app-auth-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterAuthComponent {
  formRegister: FormGroup;
  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';
  durationInSeconds = 5;

  constructor(
    private fb:FormBuilder,
    private authService: AuthApiService,
    private _snackBar: MatSnackBar,
    private router: Router,
  ){
    //creamos el formulario
    this.formRegister = this.fb.group({
      username: ['',Validators.required],
      password: ['',Validators.required],
      name: ['',Validators.required],
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

  //metodo que realiza el registro de un usuario
  registerUser():void{

    const user:RegisterModel={
      username: this.formRegister.value.username,
      password: this.formRegister.value.password,
      name: this.formRegister.value.name
    };

    this.authService.registerUser(user).subscribe({
      next:(data) =>{
        this.mostrarAlerta('El registro se realizo correctamente','Ok');
        this.router.navigate(['/auth']);
      }

      });
  }
}

