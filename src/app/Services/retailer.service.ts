import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";

import { FileToUpload } from "../models/FileToUpload";
import { Observable } from 'rxjs';
import { Retailer } from "../models/retailer.model";

@Injectable(  {providedIn: 'root'})

export class RetailerService{

    url:string="http://localhost:38181/api/Retailer";
    constructor(private client:HttpClient)
    {
    }

    httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json'})
    }
  
    RetailerLogin(retailer: Retailer) {
      return this.client.post(this.url+'/RetailerLogin', JSON.stringify(retailer), this.httpOptions);
    }

    RetailerRegister(retailer:Retailer){
        return this.client.post(this.url+'/RetailerRegister',retailer);
    }

    RetailerProducts(retaileremail:any){
      const httpheader={headers:new HttpHeaders({'Content-Type':'text/html'})};
      return this.client.post(this.url+"/RetailerProducts?retaileremail="+retaileremail,JSON.stringify(retaileremail), this.httpOptions);
    }

    RemoveProduct(productid:any)
    {
      const httpheader={headers:new HttpHeaders({'Content-Type':'text/html'})};
      return this.client.put(this.url+"/RemoveProduct?productid="+productid,JSON.stringify(productid),httpheader)
    }
   
    UploadFile(productid:any,theFile: FileToUpload) : Observable<any>
    {
   
      return this.client.post<FileToUpload>(
               this.url+"/AddProductImage?productid="+productid, theFile, this.httpOptions);
    }

    RetailerDetails(retaileremail:any)
    {
    const httpheader={headers:new HttpHeaders({'Content-Type':'text/html'})};
    return this.client.get(this.url+"/RetailerDetails?retaileremail="+retaileremail)
    } 
    
   
   
}