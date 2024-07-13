import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import { Book } from '../../interfaces/book.interface';
import { BooksApiService } from '../../services/books.service';
import { ModalAddEditComponent } from '../modals/add-edit/modal-add-edit.component';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { ModalDeleteComponent } from '../modals/delete/delete.component';
import { ModalLendComponent } from '../modals/lend/lend.component';
import { ModalReturnComponent } from '../modals/return/return.component';


@Component({
  selector: 'app-books-list',
  templateUrl: './list.component.html',
  styleUrl: './list.component.css'
})
export class ListBooksComponent implements AfterViewInit, OnInit{
  displayedColumns: string[] = ['Id', 'Titulo', 'Autor', 'Stock','Prestados','Disponibles','Acciones'];
  dataSource = new MatTableDataSource<Book>();
  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';
  durationInSeconds = 5;

   @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private service: BooksApiService,
    public dialog: MatDialog,
    private _snackBar: MatSnackBar,
  ){  }

  ngOnInit(): void {
    this.listBooks();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  newBook() {
    const dialogRef = this.dialog.open(ModalAddEditComponent,
      {
        disableClose:true,
        width:'450px'
      });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
      this.listBooks();
    });
  }

  editBook(book: Book){
    const dialogRef = this.dialog.open(ModalAddEditComponent,
      {
        disableClose:true,
        width:'450px',
        data: book
      });

    dialogRef.afterClosed().subscribe(result => {
      if(result === 'editado'){
        this.listBooks();
      }
      console.log(`Dialog result: ${result}`);
    });
  }

  listBooks(){
    this.service.getItems().subscribe({
      next:(dataResponse) =>{
        console.log(dataResponse);
        this.dataSource.data = dataResponse;
      },
      error:(e)=>{
        this.mostrarAlerta('Sin datos','Error');
      }
    });
  }

  deleteBook(book: Book):void{
    if(book.stock==0)
    {
      this.dialog.open(ModalDeleteComponent,
        {
          disableClose:true,
          data: book
        }).afterClosed().subscribe(resultado =>{
          if(resultado ==='eliminar'){
            this.service.deleteItems(book.id).subscribe({
              next:(data)=>{
                this.mostrarAlerta('El libro fue eliminado','Ok');
                this.listBooks();
              },
              error:(e)=>{
                this.mostrarAlerta('No se pudo crear','Error');
              }
            })
          }
        })
    }
    else{
      this.mostrarAlerta('No se puede eliminar un libro con Stock','Error');
    }
  }

  lendBook(book:Book):void{
    if(book.available>0){
      this.dialog.open(ModalLendComponent,
      {
        disableClose:true,
        data: book
      }).afterClosed().subscribe(resultado =>{
        if(resultado ==='prestar'){
          book.lentBooks+=1;
          book.available-=1;
          this.service.updateItem(book.id, book).subscribe({
            next:(data)=>{
              this.mostrarAlerta('El libro fue prestado','Ok');
              this.listBooks();
            },
            error:(e)=>{
              this.mostrarAlerta('No se pudo prestar','Error');
            }
          })
        }
      });
    }
    else{
      this.mostrarAlerta('No hay libros disponibles','Error');
    }

  }

  returnBook(book:Book):void{
    if(book.lentBooks>0){
      this.dialog.open(ModalReturnComponent,
      {
        disableClose:true,
        data: book
      }).afterClosed().subscribe(resultado =>{
        if(resultado ==='devolver'){
          book.available+=1;
          book.lentBooks-=1;
          this.service.updateItem(book.id, book).subscribe({
            next:(data)=>{
              this.mostrarAlerta('El libro fue devuelto','Ok');
              this.listBooks();
            },
            error:(e)=>{
              this.mostrarAlerta('No se pudo devolver','Error');
            }
          })
        }
      });
    }
    else{
      this.mostrarAlerta('No hay libros prestados','Error');
    }

  }

  mostrarAlerta(message: string, action: string) {
    this._snackBar.open(message, action,{
        horizontalPosition: this.horizontalPosition,
        verticalPosition: this.verticalPosition,
        duration: this.durationInSeconds * 1000
      });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}

