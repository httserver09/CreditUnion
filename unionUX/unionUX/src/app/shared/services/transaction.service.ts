import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

interface Transaction {
  Id: number,
  amount: number,    
  deducted: number,
  transactionDate: Date, 
  transactionStatus: string,
  accountId: number
}

@Injectable({
  providedIn: 'root'
})
export class TransactionService {
  readonly APIUrl = "https://localhost:44328/api/";

  constructor(private http: HttpClient) { }

  getTransactions(): Observable<any[]>{
    return this.http.get<any>(this.APIUrl + 'Transaction/get');
  }

  getTransactionById(transactionId: number): Observable<Transaction> {
    return this.http.get<Transaction>(this.APIUrl + 'Transaction/get' + transactionId);
  }

  getTransactionsOnAnAccount(accountId: number): Observable<Transaction> {
    return this.http.get<Transaction>(this.APIUrl + 'Transaction/getTransactionsOnAnAccount/' + accountId);
  }

  addTransaction(val: any){
    return this.http.post(this.APIUrl + 'Transaction/Post', val);
  }

  updateTransaction(val: any){
    return this.http.put(this.APIUrl + 'Transaction/put', val);
  }

  deleteTransaction(transactionId: any){
    return this.http.delete(this.APIUrl + 'Transaction/delete/' + transactionId);
  }
}
