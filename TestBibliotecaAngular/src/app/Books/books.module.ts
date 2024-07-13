import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListBooksComponent } from './components/list/list.component';
import { MaterialModule } from '../material/material.module';
import { HttpClientModule } from '@angular/common/http';
import { ModalAddEditComponent } from './components/modals/add-edit/modal-add-edit.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalDeleteComponent } from './components/modals/delete/delete.component';
import { ModalLendComponent } from './components/modals/lend/lend.component';
import { ModalReturnComponent } from './components/modals/return/return.component';

@NgModule({
  declarations: [
    ListBooksComponent,
    ModalAddEditComponent,
    ModalDeleteComponent,
    ModalLendComponent,
    ModalReturnComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  exports:[
    ListBooksComponent,
    ModalAddEditComponent
  ]
})
export class BooksModule { }
