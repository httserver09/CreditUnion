import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DefaultModule } from './layouts/default/default.module';
import { BeneficiaryComponent } from './modules/beneficiary/beneficiary.component';
import { MatTableModule } from '@angular/material/table';
import { AccountsComponent } from './modules/accounts/accounts.component';

@NgModule({
  declarations: [
    AppComponent,
    BeneficiaryComponent,
    AccountsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    DefaultModule,
    MatTableModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
