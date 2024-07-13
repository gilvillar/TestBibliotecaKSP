import { Component } from '@angular/core';
import { FormBuilder,FormGroup,Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
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
    private bookService: BooksApiService
  ) {
    this.formBook = this.fb.group({
      title: ['',Validators.required],
      author: ['',Validators.required],
      isFree: [true]
    });
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
      isFree: this.formBook.value.isFree
    }

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
}
