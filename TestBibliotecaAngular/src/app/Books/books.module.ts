import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListBooksComponent } from './components/list/list.component';
import { MaterialModule } from '../material/material.module';
import { HttpClientModule } from '@angular/common/http';
import { ModalAddEditComponent } from './components/modal/modal.component';

@NgModule({
  declarations: [
    ListBooksComponent,
    ModalAddEditComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    HttpClientModule,
  ],
  exports:[
    ListBooksComponent,
    ModalAddEditComponent
  ]
})
export class BooksModule { }
