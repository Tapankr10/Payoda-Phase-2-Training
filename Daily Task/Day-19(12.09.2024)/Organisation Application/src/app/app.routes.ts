import { Routes } from '@angular/router';
import { OrgListComponent } from './org-list/org-list.component';
import { OrgDetailComponent } from './org-detail/org-detail.component';
import { AddCompanyComponent } from './add-company/add-company.component';
import { UpdateCompanyComponent } from './update-company/update-company.component';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

export const routes: Routes = [
{path:'',component:OrgListComponent},
{ path: 'comp/:id', component:OrgDetailComponent },
{ path: 'add', component: AddCompanyComponent },
{ path: 'update/:id', component: UpdateCompanyComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }