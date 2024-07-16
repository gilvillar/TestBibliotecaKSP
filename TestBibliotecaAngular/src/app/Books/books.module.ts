import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BooksRoutingModule } from './books-routing.module';

import { MaterialModule } from '../material/material.module';

import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalDeleteComponent } from './components/modals/delete/delete.component';
import { ModalLendComponent } from './components/modals/lend/lend.component';
import { ModalReturnComponent } from './components/modals/return/return.component';

import { ModalAddEditComponent } from './components/modals/add-edit/modal-add-edit.component';
import { ListBooksComponent } from './components/list/list.component';
import { LayoutPageBooksComponent } from './pages/layout-page/layout-page.component';

@NgModule({
  declarations: [
    ListBooksComponent,
    ModalAddEditComponent,
    ModalDeleteComponent,
    ModalLendComponent,
    ModalReturnComponent,
    LayoutPageBooksComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    HttpClientModule,
    ReactiveFormsModule,
    BooksRoutingModule
  ],
  exports:[
    LayoutPageBooksComponent
  ]
})
export class BooksModule { }
