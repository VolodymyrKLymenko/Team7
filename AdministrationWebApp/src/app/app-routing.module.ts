import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthModule } from 'src/components/auth/auth.module';
import { RegistrationModule } from 'src/components/registration/registration.module';
import { AdministrationModule } from 'src/components/administration/administration.module';
import { SuperAdminModule } from 'src/components/superadmin/superadmin.module';
import { AuthGuard } from 'src/core/guards/auth.guard';


const routes: Routes = [
  {
    path: 'login',
    loadChildren: () => AuthModule
  },
  {
    path: 'registration',
    loadChildren: () => RegistrationModule
  },
  {
    path: 'admin',
    canActivate: [AuthGuard],
    loadChildren: () => AdministrationModule,
    data: {
      expectedRole: 'admin'
    }
  },
  {
    path: 'superadmin',
    canActivate: [AuthGuard],
    loadChildren: () => SuperAdminModule,
    data: {
      expectedRole: 'super-admin'
    }
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
