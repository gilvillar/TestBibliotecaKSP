import { Component,Inject,OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Book } from '../../../interfaces/book.interface';



@Component({
  selector: 'app-return-modal',
  templateUrl: './return.component.html',
  styleUrl: './return.component.css'
})
export class ModalReturnComponent {
  titleAction: string = 'Devolver';

  constructor(
    private dialogReference: MatDialogRef<ModalReturnComponent>,
    @Inject(MAT_DIALOG_DATA) public bookData: Book
  ){}

  confirmReturn(){
    if(this.bookData){
      this.dialogReference.close('devolver');
    }
  }
}
