//este componente gestiona la eliminacion de un libro en una ventana de dialogo

import { Component,Inject,OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Book } from '../../../interfaces/book.interface';

@Component({
  selector: 'app-delete-modal',
  templateUrl: './delete.component.html',
  styleUrl: './delete.component.css'
})
export class ModalDeleteComponent {
  titleAction: string = 'Eliminar'

  constructor(
    private dialogReference: MatDialogRef<ModalDeleteComponent>, //inyectamos una referencia del mismo componente
    @Inject(MAT_DIALOG_DATA) public bookData: Book //inyectamos la información del libro si es que existe
  ){}

    //metodo que confirma la eliminacion del libro
  confirmDelete(){
    if(this.bookData){
      this.dialogReference.close("eliminar")
    }
  }
}
