import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

interface Food {
  value: string;
  viewValue: string;
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

  fullname: string = " ";

  control: FormControl;

  banks: Food[] = [
    {value: 'Chase-0', viewValue: 'Chase'},
    {value: 'Wells Fargo', viewValue: 'Wells Fargo'},
    {value: 'BankOfAmerica', viewValue: 'Bank Of America'}
  ];

  constructor(private _formBuilder: FormBuilder) {
    this.control = _formBuilder.control({value: 'first', disabled: true});
   }
              
  ngOnInit(): void {
    this.firstFormGroup = this._formBuilder.group(
      {
        first: ['', Validators.required],
        second: ['', Validators.required],
        third: ['', Validators.required],
        fourth: ['', Validators.required],
        fifth: ['', Validators.required]
      }
    );

    this.secondFormGroup = this._formBuilder.group(
      {
        first: ['', Validators.required],
        second: ['', Validators.required],
        third: ['', Validators.required],
        fourth: ['', Validators.required],
        fifth: ['', Validators.required]
      }
    );
  }

  onSubmit()
  {
    console.log('First Form: ' + this.firstFormGroup.value);

    this.secondFormGroup = this.firstFormGroup;

    console.log('First Form: ' + this.secondFormGroup.value);
  }

  getDisabledValue() {
    //your condition, in this case textarea will be disbaled.
    return true; 
  }
}

