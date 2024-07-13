
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BooksApiService {
  private apiUrl = 'https://localhost:7164/api/Book'; // Reemplaza con la URL de tu API

  constructor(private http: HttpClient) { }

  // Ejemplo de GET request
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

// // Ejemplo de POST request
// addItem(item: any): Observable<any> {
//   const httpOptions = {
//     headers: new HttpHeaders({
//       'Content-Type': 'application/json'
//     })
//   };
//   return this.http.post<any>(`${this.apiUrl}/items`, item, httpOptions)
//     .pipe(
//       catchError(this.handleError<any>('addItem'))
//     );
// }

// // Manejo de errores
// private handleError<T>(operation = 'operation', result

