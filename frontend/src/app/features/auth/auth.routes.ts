import { Routes } from '@angular/router';
import { AuthGuard } from 'src/app/core/guards/auth.guard';

export const authRoutes: Routes = [
  {
    path: 'login',
    loadComponent() {
      return import('./pages/login/login-page.component').then(m => m.LoginPageComponent);
    },
  },
  {
    path: 'signup',
    loadComponent() {
      return import('./pages/signup/signup-page.component').then(m => m.SignupPageComponent);
    }
  }
];