import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BeneficiaryService } from 'src/app/shared/services/beneficiary.service';

interface Food {
  value: string;
  viewValue: string;
}

interface Account {
  value: number;
  valuecount: string;
  viewValue: string;
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

  accounts: Account[] = [
    {  value: 1, valuecount: '1 (Savings Account) ', viewValue: 'Savings account'},
    {  value: 2, valuecount: '2 (Cheque Account) ', viewValue: 'Checking account'}
  ];

  fullname = new FormControl({ value: null, disabled: true });
  bankName = new FormControl({ value: null, disabled: true });
  accountNumber = new FormControl({ value: null, disabled: true });
  yourRef = new FormControl({ value: null, disabled: true });
  beneficiaryReference = new FormControl({ value: null, disabled: true });
  accountId = new FormControl({value: '', disabled: true});


  addedBeneficiary = new FormControl({value: '', disabled: true});
  amount = new FormControl({value: '', disabled: false});
              
  constructor(private _formBuilder: FormBuilder,
              private beneficiaryService: BeneficiaryService) { }
              
    

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
    alert(this.firstFormGroup);

    console.log('First Form: ' + this.firstFormGroup);

    this.secondFormGroup = this.firstFormGroup;

    console.log('Second Form: ' + this.secondFormGroup);
  }

  onSubmitSecond() {
    console.log('First form: ' + this.firstFormGroup);
    console.log('Second form: ' + this.secondFormGroup);
    // this.beneficiaryService.addBeneficiary(this.secondFormGroup.value);

    this.beneficiaryService.addBeneficiary(this.secondFormGroup.value).subscribe(data => {
      this.addBeneficiaryResponse = data;
      alert(this.addBeneficiaryResponse);

      console.log(this.secondFormGroup.value);

      console.log(this.secondFormGroup.value.fullname);

      
    });

    // get the beneficiary/account information
    
    // this.beneficiaryService.getBeneficiaryById().subscribe(data => {
    //     this.accountToPay = data;
    //     alert(data);
    // });
  }

  onSubmitthird() {
    console.log("I am on my third method");
  }

  getDisabledValue() {
    //your condition, in this case textarea will be disbaled.
    return true; 
  }
}

