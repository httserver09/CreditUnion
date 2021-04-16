import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AccountService } from 'src/app/shared/services/account.service';
import { BeneficiaryService } from 'src/app/shared/services/beneficiary.service';
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

interface Ben {
  Id: number;
  fullname: string;
  bankName : string
  accountNumber : string
  yourRef : string
  beneficiaryReference: string
  accountId: number
}

interface Transaction {
  amount: number,    
  deducted: number,
  transactionDate: Date, 
  transactionStatus: string,
  accountId: number
}

@Component({
  selector: 'app-transfer',
  templateUrl: './transfer.component.html',
  styleUrls: ['./transfer.component.css']
})
export class TransferComponent implements OnInit {
  isLinear = true;
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  thirdFormGroup: FormGroup;

  addBeneficiaryResponse: any = "";

  accountToPay : Ben;

  control: FormControl;

  banks: Food[] = [
    {value: 'Chase Bank', viewValue: 'Chase'},
    {value: 'Wells Fargo', viewValue: 'Wells Fargo'},
    {value: 'Bank Of America', viewValue: 'Bank Of America'}
  ];

  accounts: Account[];
  accId: number = 1;

  trans: Transaction;
  transactionPostResponse: any;

  fullname = new FormControl({ value: null, disabled: true });
  bankName = new FormControl({ value: null, disabled: true });
  accountNumber = new FormControl({ value: null, disabled: true });
  yourRef = new FormControl({ value: null, disabled: true });
  beneficiaryReference = new FormControl({ value: null, disabled: true });
  accountId = new FormControl({value: '', disabled: true});

  amountAcc : string = '';
  paymentProcessResponse: any = '';

  addedBeneficiary = new FormControl({value: '', disabled: true});
  amount = new FormControl({value: '', disabled: false});
              
  constructor(private _formBuilder: FormBuilder,
              private beneficiaryService: BeneficiaryService,
              private accountService: AccountService,
              private transactionService: TransactionService)
  { 
    console.log('Id: ' + this.accId);

      accountService.getAccountsOfClient(this.accId).subscribe(data => {
        this.accounts = data;

        console.log('Accounts for ID: ' + this.accounts);
      });
  }

  ngOnInit(): void {
    this.firstFormGroup = this._formBuilder.group(
      {
        fullname: ['', Validators.required],
        bankName: ['', Validators.required],
        accountNumber: ['', Validators.required],
        yourRef: ['', Validators.required],
        beneficiaryReference: ['', Validators.required],
        accountId: ['', Validators.required ]
      }
    );

    this.secondFormGroup = this._formBuilder.group(
      {
        fullname: new FormControl({value: '', disabled: true}, Validators.required),
        bankName: new FormControl({value: '', disabled: true}, Validators.required),
        accountNumber: new FormControl({value: '', disabled: true}, Validators.required),
        yourRef: new FormControl({value: '', disabled: true}, Validators.required),
        beneficiaryReference: new FormControl({value: '', disabled: true}, Validators.required),  
        accountId: new FormControl({value: '', disabled: true}, Validators.required) 
      }
    );

    this.thirdFormGroup = this._formBuilder.group(
      {
        addedBeneficiary: new FormControl({value: '', disabled: true}, Validators.required),
        amount: new FormControl({value: '', disabled: false}, Validators.required), 
      }
    );
  }

  onSubmit()
  {
    console.log('First Form: ' + this.firstFormGroup);

    this.secondFormGroup = this.firstFormGroup;

    console.log('Second Form: ' + this.secondFormGroup);
  }

  onSubmitSecond() {
    console.log('First form: ' + this.firstFormGroup);
    console.log('Second form: ' + this.secondFormGroup);

    this.beneficiaryService.addBeneficiary(this.secondFormGroup.value).subscribe(data => {
      this.addBeneficiaryResponse = data;
      
      console.log(this.secondFormGroup.value);

      console.log(this.secondFormGroup.value.fullname);
    });
  }

  onSubmitthird() {
    console.log('Third form: ' + this.thirdFormGroup.value.amount);
    console.log(this.secondFormGroup.value.accountId);
    
    this.amountAcc = this.thirdFormGroup.value.amount + ',' + this.secondFormGroup.value.accountId;

    console.log('Payment to be made: ' + this.amountAcc);

    //build transaction object
    this.trans = {
      amount:  0.00,
      deducted: this.thirdFormGroup.value.amount,
      transactionDate: new Date(),
      transactionStatus: 'Successful',
      accountId: this.secondFormGroup.value.accountId
    }

    this.transactionService.addTransaction(this.trans).subscribe(data => {
      this.transactionPostResponse = data;

      this.accountService.makepaymentOnAccount(this.amountAcc).subscribe(data => {
        this.paymentProcessResponse = data;
      });
    })

   




    //log transaction record
    console.log('Amount: ' + 0.00)
    console.log('Deducted: ' + this.thirdFormGroup.value.amount)
    console.log('Date: ' + new Date());
    console.log('Status: Successful')
    console.log('Account Id: ' + this.secondFormGroup.value.accountId);
  }
}

