import { Routes } from '@angular/router';
import { StartPageComponent } from './pages/start-page/start-page.component';
import { PostsPageComponent } from './pages/posts-page/posts-page.component';
import { ExplorePageComponent } from './pages/explore-page/explore-page.component';
import { AboutPageComponent } from './pages/about-page/about-page.component';

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
    component: PostsPageComponent
  },
  {
    path: 'explore',
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
