import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

interface Client {
  id: number;
  fullname: string;
  bankName : string
  accountNumber : string
  yourRef : string
  beneficiaryReference: string
  accountId: number
}

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  readonly APIUrl = "https://localhost:44328/api/";

  constructor(private http: HttpClient) { }

  getClients(): Observable<any[]>{
    return this.http.get<any>(this.APIUrl + 'Client/get');
  }

  getClientById(clientId: number): Observable<Client> {
    return this.http.get<Client>(this.APIUrl + 'Client/get' + clientId);
  }

  addClient(val: any){
    return this.http.post(this.APIUrl + 'Client/Post', val);
  }

  updateClient(val: any){
    return this.http.put(this.APIUrl + 'Client/put', val);
  }

  deleteClient(id: any){
    return this.http.delete(this.APIUrl + 'Client/delete/' + id);
  }
}
