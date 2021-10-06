using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineShopppingAPI.Models
{
    public partial class TblOrder
    {
        public int Orderid { get; set; }
        public DateTime Orderdate { get; set; }
        public string Useremail { get; set; }
        public int? Productid { get; set; }
        public int? Retailerid { get; set; }
        public int? Orderquantity { get; set; }
        public int? Orderprice { get; set; }

        public virtual TblProduct Product { get; set; }
        public virtual TblRetailer Retailer { get; set; }
        public virtual TblUser UseremailNavigation { get; set; }
    }
}
