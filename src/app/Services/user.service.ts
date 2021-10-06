import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "../models/user.model";

import { Observable } from 'rxjs';

@Injectable(  {providedIn: 'root'})
export class UserService{
    url:string="http://localhost:38181/api/User";
    constructor(private client:HttpClient)
    {

    }
    httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json'})
    }
  
    UserLogin(user: User) {
      return this.client.post(this.url+'/UserLogin', JSON.stringify(user), this.httpOptions);
    }
    AddUser(user:User)
    {
        return this.client.post(this.url+"/AddUser",JSON.stringify(user), this.httpOptions);
    }

    UserDetails(usermail:string)
    {
      return this.client.get("http://localhost:38181/api/User/GetUserDetails?umail="+usermail)
    }
    
    GetUserOrders(usermail:string)
    {
      return this.client.get("http://localhost:38181/api/User/GetUserOrders?umail="+usermail)
    }
   
}