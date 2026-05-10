import { Routes } from '@angular/router';
import { StartPageComponent } from './pages/start-page/start-page.component';
import { PostsPageComponent } from './pages/posts-page/posts-page.component';
import { PostDetailPageComponent } from './pages/post-detail-page/post-detail-page.component';
import { ExplorePageComponent } from './pages/explore-page/explore-page.component';
import { AboutPageComponent } from './pages/about-page/about-page.component';
import { AuthGuard } from './core/guards/auth.guard';

export const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () =>
      import('./features/auth/auth.routes')
        .then(m => m.authRoutes)
  },
  {
    path: '',
    component: StartPageComponent
  },
  {
    path: 'posts',
    canActivate: [AuthGuard],
    component: PostsPageComponent
  },
  {
    path: 'post/:postId',
    canActivate: [AuthGuard],
    component: PostDetailPageComponent
  },
  {
    path: 'explore',
    canActivate: [AuthGuard],
    component: ExplorePageComponent
  },
  {
    path: 'about',
    component: AboutPageComponent
  },
  {
    path: '**',
    redirectTo: ''
  }
];
