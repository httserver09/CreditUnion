import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DefaultModule } from './layouts/default/default.module';
import { TransferComponent } from './modules/transfer/transfer.component';
import { TransferHistComponent } from './modules/transfer-hist/transfer-hist.component';
import { TransferSummComponent } from './modules/transfer-summ/transfer-summ.component';
import { MessagesComponent } from './modules/messages/messages.component';
import { TicketsComponent } from './modules/tickets/tickets.component';

@NgModule({
  declarations: [
    AppComponent,
    TransferComponent,
    TransferHistComponent,
    TransferSummComponent,
    MessagesComponent,
    TicketsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    DefaultModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
