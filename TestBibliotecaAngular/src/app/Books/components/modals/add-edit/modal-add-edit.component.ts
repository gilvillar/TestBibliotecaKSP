import { Component, inject, Inject, OnInit } from '@angular/core';
import { FormBuilder,FormGroup,Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { Book } from '../../../interfaces/book.interface';
import { BooksApiService } from '../../../services/books.service';

@Component({
  selector: 'app-add-edit-modal',
  templateUrl: './modal-add-edit.component.html',
  styleUrl: './modal-add-edit.component.css'
})
export class ModalAddEditComponent {
  formBook: FormGroup;
  titleAction: string = 'Nuevo';
  buttonAction: string = 'Guardar';
  listBooks: Book[]=[];
  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';
  durationInSeconds = 5;

  constructor(
    private dialogReference: MatDialogRef<ModalAddEditComponent>,
    private fb:FormBuilder,
    private _snackBar: MatSnackBar,
    private bookService: BooksApiService,
    @Inject(MAT_DIALOG_DATA)public dataBook:Book
  ) {
    this.formBook = this.fb.group({
      id: [0],
      title: ['',Validators.required],
      author: ['',Validators.required],
      stock: [0,Validators.required],
      lendBooks:[0],
      available:[0]
    });
  }

  ngOnInit():void{
    if(this.dataBook){
      this.formBook.patchValue({
        id: this.dataBook.id,
        title: this.dataBook.title,
        author: this.dataBook.author,
        stock: this.dataBook.stock,
        lendBooks:this.dataBook.lendBooks,
        available:this.dataBook.available,
      });

      this.titleAction= 'Editar';
    }
  }

  mostrarAlerta(message: string, action: string) {
    this._snackBar.open(message, action,{
        horizontalPosition: this.horizontalPosition,
        verticalPosition: this.verticalPosition,
        duration: this.durationInSeconds * 1000
      });
  }

  addEditBook(){
    const book:Book={
      id: 0,
      title: this.formBook.value.title,
      author: this.formBook.value.author,
      stock: this.formBook.value.stock,
      lendBooks: this.formBook.value.lendBooks,
      available: this.formBook.value.stock - this.formBook.value.lendBooks
    };

    if(this.dataBook==null){
      this.bookService.addItems(book).subscribe({
        next:(data)=>{
          this.mostrarAlerta('El libro fue creado','Ok');
          this.dialogReference.close('creado');
        },
        error:(e)=>{
          this.mostrarAlerta('No se pudo crear','Error');
        }
      })
    }
    else{
      if(book.stock < book.lendBooks){
        this.mostrarAlerta('El stock no puede ser menor que los libros prestados','Error');
      }
      else{
        book.id = this.dataBook.id;

        this.bookService.updateItem(book.id,book).subscribe({
          next:(data)=>{
            this.mostrarAlerta('El libro fue modificado','Ok');
            this.dialogReference.close('editado');
          },
          error:(e)=>{
            this.mostrarAlerta('No se pudo editar','Error');
          }
        });
      }
    }
  }
}
