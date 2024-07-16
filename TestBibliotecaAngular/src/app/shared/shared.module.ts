import { Error404PageComponent } from './error404-page/error404-page.component';
import { NgModule } from '@angular/core';
import { SharedSidebarComponent } from './sidebar/sidebar.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    Error404PageComponent,
    SharedSidebarComponent
  ],
  imports:[
    RouterModule,
    CommonModule
  ],
  exports: [
    SharedSidebarComponent
  ]
})
export class SharedModule { }
