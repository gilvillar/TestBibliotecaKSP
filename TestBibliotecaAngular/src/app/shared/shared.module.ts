import { Error404PageComponent } from './error404-page/error404-page.component';
import { NgModule } from '@angular/core';
import { SharedSidebarComponent } from './sidebar/sidebar.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    Error404PageComponent,
    SharedSidebarComponent
  ],
  imports:[
    RouterModule
  ],
  exports: [
    SharedSidebarComponent
  ]
})
export class SharedModule { }
