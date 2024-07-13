import { Component,Inject,OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Book } from '../../../interfaces/book.interface';


@Component({
  selector: 'app-lend-modal',
  templateUrl: './lend.component.html',
  styleUrl: './lend.component.css'
})
export class ModalLendComponent {
   titleAction: string = 'Prestar';

   constructor(
    private dialogReference: MatDialogRef<ModalLendComponent>,
    @Inject(MAT_DIALOG_DATA) public bookData: Book
  ){}

  confirmLend(){
    if(this.bookData){
      this.dialogReference.close("prestar")
    }
  }
}
