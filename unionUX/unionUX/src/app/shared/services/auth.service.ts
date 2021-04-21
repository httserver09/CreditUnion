import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { map } from "rxjs/operators";

// interface IUser {
//   username: string;
//   email: string;
//   role: string;
//   title: string;
// }

interface IUser {
  username: string;
  email: string;
}


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  readonly APIUrl = "https://localhost:44328/api/";

  isLoggedIn : boolean;

  currentUser: IUser = {
    username: null,
    email: null,
  };

  constructor(private http: HttpClient) { }

  // login(){
  //   this.isLoggedIn = true;
  // }

  login(val: any): Observable<IUser>{
    return this.http.post(this.APIUrl + 'Identity/Login', val).pipe(
      map((response: any) => {

        // const decodedToken = this.helper.decodeToken(response.token);

        //temporary
        this.isLoggedIn = response.result.succeeded;
        // this.currentUser.username = response.username;
        // this.currentUser.email = response.email;

        //extract information form decoded token
        this.currentUser.username = response.username;
        this.currentUser.email = response.email;
        // this.currentUser.username = decodedToken.given_name;
        // this.currentUser.email = decodedToken.email;
        // this.currentUser.role = decodedToken.role;
        // this.currentUser.title = decodedToken.Title;

        localStorage.setItem('token', response.token);

        return this.currentUser;
      })
    );
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

  getValues(): Observable<string[]>{
    return this.http.get<string[]>(this.APIUrl + 'Values', this.getHttpOptions());
  }

  getHttpOptions(){
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token'),
      }),
    };

    return httpOptions;
  } 
}
