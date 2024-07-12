
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
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

