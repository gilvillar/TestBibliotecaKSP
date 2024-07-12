import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { Book } from '../interfaces/book.interface';
import { BooksApiService } from '../../services/books.service';
import { MatDialog } from '@angular/material/dialog';
import { ModalAddEditComponent } from '../modal/modal.component';


@Component({
  selector: 'app-books-list',
  templateUrl: './list.component.html',
  styleUrl: './list.component.css'
})
export class ListBooksComponent implements AfterViewInit, OnInit{
  displayedColumns: string[] = ['Id', 'Titulo', 'Autor', 'Disponible','Acciones'];
  listado: Book[] = [];
  dataSource = new MatTableDataSource<Book>();

   @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private service: BooksApiService,
    public dialog: MatDialog
  ){  }

  ngOnInit(): void {
    this.listarLibros();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  openDialog() {
    const dialogRef = this.dialog.open(ModalAddEditComponent);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  listarLibros(){
    this.service.getItems().subscribe({
      next:(dataResponse) =>{
        console.log(dataResponse);
        this.dataSource.data = dataResponse;
      },
      error:(e)=>{}
    });
  }

  deleteBook(id: number):void{
    this.service.deleteItems(id).subscribe(
      () => {
        console.log(`Book with id ${id} deleted successfully`);
        this.listarLibros();
        // Aquí puedes agregar cualquier lógica adicional, como actualizar la vista
      },
      (error) => {
        console.error(`Error deleting book with id ${id}`, error);
      }
    );
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}

