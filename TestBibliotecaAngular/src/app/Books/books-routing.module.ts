import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LayoutPageBooksComponent } from './pages/layout-page/layout-page.component';

//configuracion para las ruts hijas. Aqui cargamos la pagina principal de libros
const routes: Routes = [
  { path: '', component: LayoutPageBooksComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BooksRoutingModule { }
