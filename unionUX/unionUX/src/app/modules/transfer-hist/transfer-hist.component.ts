import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { AccountService } from 'src/app/shared/services/account.service';
import { TransactionService } from 'src/app/shared/services/transaction.service';


interface Food {
  value: string;
  viewValue: string;
}

interface Account {
  id: number;
  accountType: string;
  activatedDate: Date;
  clientId: number;
  baseAmount: number;
}


export interface Transaction {
  Id: number; 
  amount: number;
  deducted: number; 
  transactionDate: Date; 
  transactionStatus: string;
  accountId : number;
}


@Component({
  selector: 'app-transfer-hist',
  templateUrl: './transfer-hist.component.html',
  styleUrls: ['./transfer-hist.component.css']
})
export class TransferHistComponent implements OnInit {
  banks: Food[] = [
    {value: 'Chase Bank', viewValue: 'Chase'},
    {value: 'Wells Fargo', viewValue: 'Wells Fargo'},
    {value: 'Bank Of America', viewValue: 'Bank Of America'}
  ];

  displayedColumns: any[] = [
    'Id', 
    'amount', 
    'deducted', 
    'transactionDate', 
    'transactionStatus', 
    'accountId'];

  bankName = new FormControl({ value: null, disabled: true });
  
  accountId: number = 1;
  myAccounts: Account[];

  clientId: number = 1;

  transactionsOnAccount : any;

  constructor(private transationService: TransactionService,
              private accountService: AccountService) { }

  ngOnInit(): void {
    this.transationService.getTransactionsOnAnAccount(this.accountId).subscribe(data => {
      this.transactionsOnAccount = data;

      console.log(this.transactionsOnAccount);
    })

    this.accountService.getAccountsOfClient(this.accountId).subscribe(data => {
      this.myAccounts = data;

      console.log('Accounts for ID: ' + this.myAccounts[0].accountType);
    });
  }

  selectedAccount($event)
  {
    this.accountId = $event;
    this.transationService.getTransactionsOnAnAccount(this.accountId).subscribe(data => {
      this.transactionsOnAccount = data;

      console.log(this.transactionsOnAccount);
    })
  }

}

