import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Admins } from "../models/admins.model";

import { Observable } from 'rxjs';

@Injectable(
      {
          providedIn: 'root'
    })

export class AdminService{
  url:string="http://localhost:38181/api/Admins";
  constructor(private client:HttpClient,private registerHttp:HttpClient)
  {}

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'})
  }

  AdminLogin(admin: Admins) {
    return this.client.post(this.url+'/AdminLogin', JSON.stringify(admin), this.httpOptions);
  }
  
 ApproveRetailers(retailerid:any)
  {
      const httpheader={headers:new HttpHeaders({'Content-Type':'text/html'})};
      return this.client.put(this.url+"/ApproveRetailer?retailerid="+retailerid,JSON.stringify(retailerid),httpheader)
  }
 
 
  GetAllRetailers()
  {
      return this.client.get(this.url+'/GetAllRetailers');
  }

  RemoveRetailer(retailerid:any)
  {
      const httpheader={headers:new HttpHeaders({'Content-Type':'text/html'})};
      return this.client.put(this.url+"/RemoveRetailer?retailerid="+retailerid,JSON.stringify(retailerid),httpheader)
  }

  GetCategories()
  {
      return this.client.get(this.url+'/GetCategories')
  }

  GetPendingProducts()
  {
      return this.client.get(this.url+'/GetPendingProducts')
  }

  ApproveProduct(productid:any)
  {
      const httpheader={headers:new HttpHeaders({'Content-Type':'text/html'})};
      return this.client.put(this.url+"/ApproveProduct?productid="+productid,JSON.stringify(productid),httpheader)
  }

  RejectProduct(productid:any)
  {
      const httpheader={headers:new HttpHeaders({'Content-Type':'text/html'})};
      return this.client.put(this.url+"/RejectProduct?productid="+productid,JSON.stringify(productid),httpheader)
  }
    
   
   
}