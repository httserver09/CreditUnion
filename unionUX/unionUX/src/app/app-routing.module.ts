import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DefaultComponent } from './layouts/default/default.component';
import { AccountsComponent } from './modules/accounts/accounts.component';
import { BeneficiaryComponent } from './modules/beneficiary/beneficiary.component';
import { DashboardComponent } from './modules/dashboard/dashboard.component';
import { MessagesComponent } from './modules/messages/messages.component';
import { PostsComponent } from './modules/posts/posts.component';
import { TicketsComponent } from './modules/tickets/tickets.component';
import { TransferHistComponent } from './modules/transfer-hist/transfer-hist.component';
import { TransferSummComponent } from './modules/transfer-summ/transfer-summ.component';
import { TransferComponent } from './modules/transfer/transfer.component';

const routes: Routes = [{
  path: '',
  component: DefaultComponent,
    children: [
    { path: '', component: DashboardComponent },
    { path: 'posts', component: PostsComponent},
    { path: 'transfer', component: TransferComponent},
    { path: 'history', component: TransferHistComponent},
    { path: 'summary', component: TransferSummComponent},
    { path: 'msgs', component: MessagesComponent},
    { path: 'tickets', component: TicketsComponent},
    { path: 'beneficiaries', component: BeneficiaryComponent},
    { path: 'accounts', component: AccountsComponent}
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
