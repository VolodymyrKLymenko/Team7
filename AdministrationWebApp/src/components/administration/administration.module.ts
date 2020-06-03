import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { CalendarModule } from 'primeng/calendar';

import { AdministrationRoutingModule } from './administration-routing.module';
import { AdministrationComponent } from './administration.component';
import { TableModule } from '../shared/table/table.module';
import { ModalModule } from '../shared/modal/modal.module';

@NgModule({
  declarations: [
    AdministrationComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AdministrationRoutingModule,
    TableModule,
    ModalModule,
    CalendarModule
  ],
  providers: []
})
export class AdministrationModule { }
