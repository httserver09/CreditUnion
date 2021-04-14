import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BeneficiaryService {

  readonly APIUrl = "https://localhost:44328/api/";

  constructor(private http: HttpClient) { }

  getBeneficiaries(): Observable<any[]>{
    return this.http.get<any>(this.APIUrl + 'Beneficiary/get');
  }

  getBeneficiariesOfAnAccount(accountId: number): Observable<any[]>{
    return this.http.get<any>(this.APIUrl + 'Beneficiary/GetBeneficiariesOfAnAccount/' + accountId);
  }

  getBeneficiaryById(beneficiaryId: any): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + 'Beneficiary/get' + beneficiaryId);
  }

  addBeneficiary(val: any){
    return this.http.post(this.APIUrl + 'Beneficiary/Post', val);
  }

  updateBeneficiary(val: any){
    return this.http.put(this.APIUrl + 'Beneficiary/put', val);
  }

  deleteBeneficiary(id: any){
    return this.http.delete(this.APIUrl + 'Beneficiary/delete/' + id);
  }
}
