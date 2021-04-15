import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/shared/services/account.service';
import { ClientService } from 'src/app/shared/services/client.service';


interface Acc {
  id: number;
  accountType: string;
  activatedDate : Date;
  clientId : number;
  baseAmount : number;
}


interface Client {
  id: number;
  fullname: string;
  bankName : string
  accountNumber : string
  yourRef : string
  beneficiaryReference: string
  accountId: number
}

[{"id":1,"accountType":"Savings","activatedDate":"2018-03-15T00:00:00","clientId":1,"baseAmount":55000}]

@Component({
  selector: 'app-accounts',
  templateUrl: './accounts.component.html',
  styleUrls: ['./accounts.component.css']
})
export class AccountsComponent implements OnInit {

  clientId: number = 1;
  client: Client;

  myAccount: Acc[];
  constructor(private accountService: AccountService,
            private clientService: ClientService ) { }

  ngOnInit(): void {
    //go fetch the account of the currently logged in user
    this.accountService.getAccountsOfClient(this.clientId).subscribe(data => {
      this.myAccount = data;

      console.log('My account: ' + this.myAccount[0].accountType);

      // console.log(JSON.stringify(this.myAccount));

    });
  }

  getRelatedClient(clientId){
    this.clientService.getClientById(clientId).subscribe(data => {
      this.client = data;
    })
  }

}
