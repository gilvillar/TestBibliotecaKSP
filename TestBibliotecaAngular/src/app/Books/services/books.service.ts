
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthApiService } from '../../auth/services/authServices';

@Injectable({
  providedIn: 'root'
})
export class BooksApiService {
  private apiUrl = 'https://localhost:7164/api/book'; // Reemplaza con la URL de tu API
  private token : string = '';

  constructor(
    private http: HttpClient,
    private authService: AuthApiService
  ) { }

  getItems(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}`);
  }

  deleteItems(id:number):Observable<any>{
    let result = this.http.delete(`${this.apiUrl}/${id}`);
    return result;
  }

  addItems(item: any):Observable<any>{
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    return this.http.post<any>(`${this.apiUrl}`, item, httpOptions)
    .pipe(
      catchError(this.handleError)
    )
  }

  updateItem(id: number, item: any):Observable<any>{
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    return this.http.put<any>(`${this.apiUrl}/${id}`, item, httpOptions)
    .pipe(
      catchError(this.handleError)
    )
  }

  lendBooks(id: number, item: any):Observable<any>{
    const currentUser = this.authService.getToken();

    if(currentUser !== null)
    {
      this.token = currentUser.token;
    }


    console.log('desde lendBooks: ',this.token)

    //"Authorization": `Bearer ${token}`

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        "Authorization": `Bearer ${this.token}`
      })
    };

    return this.http.put<any>(`${this.apiUrl}/${id}/lend`, item,httpOptions )
    .pipe(
      catchError(this.handleError)
    )
  }

  returnBooks(id: number, item: any):Observable<any>{
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    return this.http.put<any>(`${this.apiUrl}/${id}/return`, item, httpOptions)
    .pipe(
      catchError(this.handleError)
    )
  }

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
