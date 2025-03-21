import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [{ path: 'products', loadChildren: () => import('./features/products/products.module').then(m => m.ProductsModule) }, { path: 'users', loadChildren: () => import('./features/users/users.module').then(m => m.UsersModule) }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
