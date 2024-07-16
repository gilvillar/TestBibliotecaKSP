//este componente gestiona el prestamo de un libro en una ventana de dialogo

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
    private dialogReference: MatDialogRef<ModalLendComponent>, //inyectamos una referencia del mismo componente
    @Inject(MAT_DIALOG_DATA) public bookData: Book //inyectamos la información del libro si es que existe
  ){}

  //metodo que confirma el prestamo del libro
  confirmLend(){
    if(this.bookData){
      this.dialogReference.close("prestar")
    }
  }
}
