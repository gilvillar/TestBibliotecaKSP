//este componente gestiona la devolucion de un libro en una ventana de dialogo

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
    private dialogReference: MatDialogRef<ModalReturnComponent>, //inyectamos una referencia del mismo componente
    @Inject(MAT_DIALOG_DATA) public bookData: Book //inyectamos la información del libro si es que existe
  ){}

  //metodo que realiza la devolucion de un libro
  confirmReturn(){
    if(this.bookData){
      this.dialogReference.close('devolver');
    }
  }
}
