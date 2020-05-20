import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TableComponent } from './table.component';
import { PagingComponent } from '../paging/paging.component';

@NgModule({
  declarations: [
    TableComponent,
    PagingComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    TableComponent,
    PagingComponent
  ]
})
export class TableModule { }
