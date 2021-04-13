import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DefaultComponent } from './default.component';
import { DashboardComponent } from 'src/app/modules/dashboard/dashboard.component';
import { RouterModule } from '@angular/router';
import { PostsComponent } from 'src/app/modules/posts/posts.component';
import { SharedModule } from 'src/app/shared/shared.module';
import {MatSidenavModule} from '@angular/material/sidenav';
import { MatDividerModule } from '@angular/material/divider';
import { MessagesComponent } from 'src/app/modules/messages/messages.component';


import { TicketsComponent } from 'src/app/modules/tickets/tickets.component';
import { TransferComponent } from 'src/app/modules/transfer/transfer.component';
import { TransferHistComponent } from 'src/app/modules/transfer-hist/transfer-hist.component';
import { TransferSummComponent } from 'src/app/modules/transfer-summ/transfer-summ.component';

import { MatStepperModule } from '@angular/material/stepper';

import { MatFormFieldModule } from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDialogModule } from '@angular/material/dialog';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { STEPPER_GLOBAL_OPTIONS } from '@angular/cdk/stepper';

@NgModule({
  declarations: [
    DefaultComponent,
    DashboardComponent, 
    PostsComponent, 
    MessagesComponent,
    TicketsComponent,
    TransferComponent,
    TransferHistComponent,
    TransferSummComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule, 
    MatSidenavModule,
    MatDividerModule,
    MatStepperModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    MatSelectModule,
    MatDialogModule
  ],
  providers: [
    {
      provide: STEPPER_GLOBAL_OPTIONS,
      useValue: { displayDefaultIndicatorType: false }
    }
  ]
})
export class DefaultModule { }
