import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  readonly APIUrl = "https://localhost:44328/api/";

  constructor(private http: HttpClient) { }

  getAccounts(): Observable<any[]>{
    return this.http.get<any>(this.APIUrl + 'Account/get');
  }

  getAccountById(accountId: any): Observable<any> {
    return this.http.get<any>(this.APIUrl + 'Account/get' + accountId);
  }

  getAccountsOfClient(clientId: number): Observable<any>{
    return this.http.get<any>(this.APIUrl + 'Account/getAccountsOfClient/' + clientId); 
  }

  addAccount(val: any){
    return this.http.post(this.APIUrl + 'Account/Post', val);
  }

  updateAccount(val: any){
    return this.http.put(this.APIUrl + 'Account/put', val);
  }

  deleteAccount(id: any){
    return this.http.delete(this.APIUrl + 'Account/delete/' + id);
  }
}
