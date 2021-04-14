import { Component, OnInit } from '@angular/core';
import { BeneficiaryService } from 'src/app/shared/services/beneficiary.service';


@Component({
  selector: 'app-beneficiary',
  templateUrl: './beneficiary.component.html',
  styleUrls: ['./beneficiary.component.css']
})
export class BeneficiaryComponent implements OnInit {
  accountId: number = 1;
  beneficiariesOfProvidedAccount: any;

  constructor(private beneficiaryService: BeneficiaryService) { }

  ngOnInit(): void {
    this.beneficiaryService.getBeneficiariesOfAnAccount(this.accountId).subscribe(data => {
      this.beneficiariesOfProvidedAccount = data;
     
      console.log(this.beneficiariesOfProvidedAccount);
    });
  }

  displayedColumns: string[] = [
    'Id', 
    'fullname', 
    'bankName', 
    'accountNumber', 
    'yourRef',
    'beneficiaryReference',
    'accountId'
  ];
}
