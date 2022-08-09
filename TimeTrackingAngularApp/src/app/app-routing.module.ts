import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CountryComponent } from './components/country/country.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { SuccesregistrationComponent } from './components/register/succesregistration/succesregistration.component';
import { StateComponent } from './components/state/state.component';
import { AddComponent } from './components/table/add/add.component';
import { DetailsComponent } from './components/table/details/details.component';
import { TableComponent } from './components/table/table.component';
import { UpdateComponent } from './components/table/update/update.component';
const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent,
  },
  {
    path: 'home/login',
    component: LoginComponent,
  },
  {
    path: 'home/register',
    component: RegisterComponent,
  },
  {
    path: 'home/register/succesregistration/:email',
    component: SuccesregistrationComponent,
  },
  {
    path: 'table',
    component: TableComponent,
  },
  {
    path: 'table/details/:id',
    component: DetailsComponent,
  },
  {
    path: 'table/add',
    component: AddComponent,
  },
  {
    path: 'table/edit/:id',
    component: UpdateComponent,
  },
  {
    path: 'table/country/:country',
    component: CountryComponent,
  },
  {
    path: 'table/state/:state/:startDate/:endDate',
    component: StateComponent,
  },
  {
    path: '**',
    redirectTo: 'home',
    pathMatch: 'full',
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      routes

      // , {
      // enableTracing: true,
      // initialNavigation: 'enabledBlocking',
      // relativeLinkResolution: 'corrected', // Fix Router BUG
      // disableUrlEncoding: true, // Suggest something like this: but would need documentation
      // }
    ),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
