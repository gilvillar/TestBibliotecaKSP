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
  displayedColumns: string[] = ['Id', 'Titulo', 'Autor', 'Disponible','Acciones'];
  listado: Book[] = [];
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

  listBooks(){
    this.service.getItems().subscribe({
      next:(dataResponse) =>{
        console.log(dataResponse);
        this.dataSource.data = dataResponse;
      },
      error:(e)=>{}
    });
  }

  deleteBook(book: Book):void{
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

  lendBook(book:Book):void{
    this.dialog.open(ModalLendComponent,
      {
        disableClose:true,
        data: book
      }).afterClosed().subscribe(resultado =>{
        if(resultado ==='prestar'){
          book.isFree=false;
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
      })
  }

  returnBook(book:Book):void{
    this.dialog.open(ModalReturnComponent,
      {
        disableClose:true,
        data: book
      }).afterClosed().subscribe(resultado =>{
        if(resultado ==='devolver'){
          book.isFree=true;
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
      })
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

