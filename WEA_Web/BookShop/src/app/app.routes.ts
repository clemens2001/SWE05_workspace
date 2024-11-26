import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BookListComponent } from './book-list/book-list.component';
import { BookDetailsComponent } from './book-details/book-details.component';
import { BookFormComponent } from './book-form/book-form.component';
import { BookRformComponent } from './book-rform/book-rform.component';
import { canNavigateToAdminGuard } from './can-navigate-to-admin.guard';
import { LoginComponent } from './login/login.component';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: HomeComponent
    },
    {
        path: 'books',
        component: BookListComponent
    },
    {
        path: 'books/:id',
        component: BookDetailsComponent
    },
    {
      path: 'admin',
      component: BookFormComponent,
    },
    {
      path: 'adminR/:id',
      component: BookRformComponent,
    }
];
