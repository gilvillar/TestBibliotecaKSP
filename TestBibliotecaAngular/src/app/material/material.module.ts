import { NgModule } from '@angular/core';
import {MatTableModule} from '@angular/material/table'
import {MatButtonModule} from '@angular/material/button';
import {MatDialogModule} from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatInputModule} from '@angular/material/input';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatSortModule} from '@angular/material/sort';
import {MatIconModule} from '@angular/material/icon';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatToolbarModule} from '@angular/material/toolbar';

@NgModule({
  exports: [
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    MatDialogModule,
    MatCheckboxModule,
    MatTableModule,
    MatPaginatorModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatIconModule,
    MatGridListModule,
    MatTooltipModule,
    MatSidenavModule,
    MatToolbarModule
  ]
})
export class MaterialModule { }
