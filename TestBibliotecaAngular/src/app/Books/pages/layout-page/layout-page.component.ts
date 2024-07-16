import { Component } from '@angular/core';
import { AuthApiService } from '../../../auth/services/authServices';

@Component({
  selector: 'app-layout-page',
  templateUrl: './layout-page.component.html',
  styleUrl: './layout-page.component.css'
})
export class LayoutPageBooksComponent {
  user: string|undefined = 'Bienvenido: ';

 constructor(
  private authService: AuthApiService,
 ){}

 ngOnInit(){
  this.getUserInfo();
 }

  getUserInfo(){

    this.authService.checkAuthentication().subscribe({
      next:(data)=>{
        if(data === ''){
          this.user = '';
        }
        else{
          this.user = this.user + data.name;
        }
      }
    });
  }
}

