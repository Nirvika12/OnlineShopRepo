import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Product } from "../models/product.model";

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  url:string="http://localhost:38181/api/Retailer";

  constructor(private http:HttpClient, private client:HttpClient, private registerHttp:HttpClient) { }
  
    httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json'})
    }

    AddProduct(retaileremail:any,product:Product)
    {
      return this.client.post(this.url+"/AddProduct?retaileremail="+retaileremail,product);
    }

    public UpdateProduct(productid:any,product:Product)
    {
      return this.client.put(this.url+"/RetailerUpdateProduct?productid="+productid,product);
    }
    
    RejectProduct(productid:any)
    {
      const httpheader={headers:new HttpHeaders({'Content-Type':'text/html'})};
      return this.client.put(this.url+"/RejectProduct?productid="+productid,JSON.stringify(productid),httpheader)
    }

  getAllProducts()
  {
    return this.http.get('http://localhost:38181/api/Products/AllProducts');
  }

  searchallProducts(s:string)
  {
    const httpheader={headers:new HttpHeaders({'Content-Type':'text/html'})};
    return this.http.get("http://localhost:38181/api/Products/SearchProduct?search="+s,httpheader);
  }

  getallcategories()
  {
    return this.http.get("http://localhost:38181/api/Products/GetCategory")
  }


}
