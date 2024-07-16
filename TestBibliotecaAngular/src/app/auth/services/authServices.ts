//componente que gestiona la comunicacion con el api

import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthApiService {
  // private apiUrl = 'https://localhost:7164/api/Auth'; // Reemplaza con la URL de tu API
  private apiUrl = 'https://apptestksp.azurewebsites.net/api/auth'

  constructor(private http: HttpClient) { }

  //metodo que realiza el registro de un usuario
  registerUser(item: any):Observable<any>{
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    return this.http.post<any>(`${this.apiUrl}/register`, item, httpOptions)
    .pipe(
      catchError(this.handleError)
    )
  }

  //metodo que realiza el login de un usuario
  login(username: string, password: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/login`, { username, password })
      .pipe(
        map (response => {

        // Almacenar el token JWT en el local storage
        if (response && response.token) {
          localStorage.setItem('currentUser', JSON.stringify({ username, token: response }));
        }
        return response;
      }),
      catchError(this.handleError)
    );
  }

  //metodo que cierra la sesión
  logout(): void {
    // Eliminar el usuario del local storage para cerrar sesión
    localStorage.removeItem('currentUser');
  }

  //metodo que obtiene el token
  getToken(): any | null {
    const currentUser = JSON.parse(localStorage.getItem('currentUser')!);
    return currentUser;
  }

  //metodo que verifica si un usuario esta logueado o no
  isLoggedIn(): boolean {
    const result =  this.getToken() !== null;
    return result
  }

  //metodo que obtiene los datos del usuario que esta logueado
  checkAuthentication(): Observable<any>{
    const currentUser = JSON.parse(localStorage.getItem('currentUser')!);
    const nothingObservable = of('');

    if(currentUser !== null){
      return this.http.get<any>(`${this.apiUrl}/User?userName=${currentUser.username}`);
    }
    else{
      return nothingObservable;
    }
  }

  //metodo que maneja los errores
  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // Error del lado del cliente
      console.error('Ocurrió un error:', error.error.message);
    } else {
      // Error del lado del servidor
      console.error(`Código de error del servidor: ${error.status}, ` + `cuerpo: ${error.error}`);
    }
    // Retorna un observable con un mensaje de error para que el componente lo maneje
    return throwError('Ocurrió un problema; por favor, inténtelo nuevamente más tarde.');
  }
}
