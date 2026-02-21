import { Routes } from '@angular/router';

import { LoginComponent } from './features/auth/login/login.component';
import { RegisterComponent } from './features/auth/register/register.component';
import { DashboardComponent } from './features/dashboard/dashboard.component';

export const routes: Routes = [

  // Default → Dashboard
  { path: '', component: DashboardComponent },

  // Auth pages
  { path: 'login', component: LoginComponent },
  
  { path: 'register', component: RegisterComponent },

  // Protected example (if needed)
  {
    path: 'dashboard',
    component: DashboardComponent
  },

  { path: '**', redirectTo: '' }
];
