import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import {EmployeeComponent} from './employee/employee.component';
import {DepartmentComponent} from './department/department.component';
import {WebpayPlusComponent} from './webpay-plus/webpay-plus.component';
import {ReturnPageComponent} from './return-page/return-page.component';
import {PageNotFoundComponent} from './page-not-found/page-not-found.component';

const routes: Routes = [
{path:'employee',component:EmployeeComponent},
{path:'department',component:DepartmentComponent},
{path:'WebpayPlus',component:WebpayPlusComponent},
{path:'ReturnPage',component:ReturnPageComponent},
{path:'', redirectTo:'/WebpayPlus', pathMatch:'full'}, // redirect to `first-component`
{path:'**', component:PageNotFoundComponent}  // Wildcard route for a 404 page
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
