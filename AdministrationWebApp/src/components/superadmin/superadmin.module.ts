import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { SuperAdminRoutingModule } from './superadmin-routing.module';
import { SuperAdminComponent } from './superadmin.component';

@NgModule({
  declarations: [
    SuperAdminComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    SuperAdminRoutingModule
  ],
  providers: []
})
export class SuperAdminModule { }
