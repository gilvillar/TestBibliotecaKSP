import { Component,Inject,OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BooksApiService } from '../../../services/books.service';
import { Book } from '../../../interfaces/book.interface';

@Component({
  selector: 'app-delete-modal',
  templateUrl: './delete.component.html',
  styleUrl: './delete.component.css'
})
export class ModalDeleteComponent {
  titleAction: string = 'Eliminar'

  constructor(
    private dialogReference: MatDialogRef<ModalDeleteComponent>,
    private bookService: BooksApiService,
    @Inject(MAT_DIALOG_DATA) public bookData: Book
  ){}

  confirmDelete(){
    if(this.bookData){
      this.dialogReference.close("eliminar")
    }
  }
}
