import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FilterService {

  constructor(private http:HttpClient) { }
  
  FilterByCategory(cat:string)
  {
    return this.http.get("http://localhost:38181/api/Filter/FilterByCategory?cname="+cat)
  }

  FilterByCategoryOnBrand(cat:string)
  {
    return this.http.get("http://localhost:38181/api/Filter/FilterByBrandOnCategory?cname="+cat)
  }

  FilterByCategoryAndBrand(cat:string, brand:string)
  {
    return this.http.get("http://localhost:38181/api/Filter/FilterByCategoryAndBrand?cname="+cat+"&bname="+brand)
  }

  FilterByPriceCategoryBrand(price:string, cat:string, brand:string)
  {
    return this.http.get("http://localhost:38181/api/Filter/FilterByPriceCategoryBrand?price="+price+"&cname="+cat+"&bname="+brand)
  }

  SortByProduct()
  {
    return this.http.get("http://localhost:38181/api/Filter/SortByProduct")
  }

  SortByProductDesc()
  {
    return this.http.get("http://localhost:38181/api/Filter/SortByProductDesc")
  }

  SortByPrice()
  {
    return this.http.get("http://localhost:38181/api/Filter/SortByPrice")
  }

  SortByPriceDesc()
  {
    return this.http.get("http://localhost:38181/api/Filter/SortByPriceDesc")
  }
}
