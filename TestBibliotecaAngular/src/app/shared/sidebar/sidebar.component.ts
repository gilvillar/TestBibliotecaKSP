import { Component } from '@angular/core';
import { AuthApiService } from '../../auth/services/authServices';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-shared-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SharedSidebarComponent {

  constructor(
    private authService: AuthApiService, //inyectamos el servicio de autorizacion
    private router: Router,
  ){

  }

  //metodo que cierra la sesión
  logout():void{
    this.authService.logout();

    this.router.navigate(['/auth']);
  }

  //metodo que verifica si el usuario esta logueado
  isLoguedIn(){
     const value = this.authService.isLoggedIn();

    //  console.log('desde el sidebar: ', value);
     return value;
  }
}
