import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  url:string="http://localhost:38181/api/Cart/";
  constructor(private http:HttpClient) { }

    RemoveProductCart(cartid : number) 
    {
        const httpheader={headers:new HttpHeaders({'Content-Type':'text/html'})};
        return  this.http.delete(this.url+"RemoveFromCart?cartid="+cartid,httpheader);
    }
    /*UpdateQuantityCart(cartid:number, productid: number, cartquantity :any){
        const httpheader={headers:new HttpHeaders({'Content-Type':'text/html'})};
        return this.updateQuantityCartHttp.put<any>(this.url+"UpdateCart?cartid="+cartid+
        "&productid="+productid+"&cartquantity="+cartquantity,httpheader);
    }*/
    
    GetCart(useremail:any)
    {
        return this.http.get(this.url+"GetCartUser?useremail="+useremail)
    }

    AddtoCart(val : any) {
        const httpheader={headers:new HttpHeaders({'Content-Type':'application/json'})};
        return this.http.post("http://localhost:38181/api/Cart/InsertIntoCart",val ,httpheader);
    }
   
    GetTotal(useremail:any)
    {
        return this.http.get(this.url+"CartTotal?useremail="+useremail)
    }

    PurchaseAllProducts(useremail:any)
    {
        const httpheader={headers:new HttpHeaders({'Content-Type':'application/json'})};
        return this.http.post("http://localhost:38181/api/Cart/PurchaseAllProducts?useremail="+useremail,httpheader);
    }

    QuantityIncr(usermail:any,pid:number)
    {
        const httpheader={headers:new HttpHeaders({'Content-Type':'application/json'})};
        return this.http.post("http://localhost:38181/api/Cart/QuantityIncr?umail="+usermail+"&pid="+pid,httpheader);
    }

    QuantityDecr(usermail:any,pid:number)
    {
        const httpheader={headers:new HttpHeaders({'Content-Type':'application/json'})};
        return this.http.post("http://localhost:38181/api/Cart/QuantityDecr?umail="+usermail+"&pid="+pid,httpheader);
    }
}
