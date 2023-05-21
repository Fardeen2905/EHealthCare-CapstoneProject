import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { IAccount } from '../models/account';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {


 
  private loggedIn : boolean = false;

  accounts : IAccount[] = []
  account : any;

  constructor(private _http : HttpClient) { }

  createAccount(account : IAccount) : Observable<IAccount>{
    return this._http.post<IAccount>('http://localhost:3001/account' , account)
    // return this._http.post<IAccount>('http://localhost:5292/api/user/getuserlist' , account)
  }

  getAccounts() : Observable<IAccount[]>{
    return this._http.get<IAccount[]>('http://localhost:3001/account')
    // return this._http.get<IAccount[]>('http://localhost:5292/api/user/getuserlist')
  }

  getAccountById(accountID : any){
    return this._http.get(`http://localhost:3001/account/${accountID}`)
    // return this._http.get(`http://localhost:5292/api/user/${getaccountID}`)
  }

  loginn(username : string , password : string){

    this.getAccounts().subscribe((result) => {
      this.accounts = result
    })

    this.account = this.accounts.find((m) => m.username === username)

    if(this.account.username === username && this.account.password === password){
      sessionStorage.setItem("user" , username)
      sessionStorage.setItem('id' , this.account.id)
      this.loggedIn = true;
      return this.loggedIn
    }else{
      this.loggedIn = false;
      return this.loggedIn;
    }

  }

  logout(){
    this.loggedIn = false;
  }

  isLoggedIn(): boolean{
    return this.loggedIn;
  }

}

