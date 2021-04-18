import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  readonly APIUrl = "https://localhost:44328/api/";

  isLoggedIn : boolean;

  constructor(private http: HttpClient) { }

  login(){
    this.isLoggedIn = true;
  }

  logout(){
    this.isLoggedIn = false;
  }

  register(model: any){
    return this.http.post(this.APIUrl + "Identity/register", model);
  }

  confirmEmail(model: any){
    return of();
  }
}
