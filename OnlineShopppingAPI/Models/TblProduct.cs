using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineShopppingAPI.Models
{
    public partial class TblProduct
    {
        public TblProduct()
        {
            TblCart = new HashSet<TblCart>();
            TblCompare = new HashSet<TblCompare>();
            TblOrder = new HashSet<TblOrder>();
            TblWishlist = new HashSet<TblWishlist>();
        }

        public int Productid { get; set; }
        public string Productname { get; set; }
        public int Productprice { get; set; }
        public int Productquantity { get; set; }
        public string Productdescription { get; set; }
        public string Productbrand { get; set; }
        public string Productimage1 { get; set; }
        public string Productnotification { get; set; }
        public string Productstatus { get; set; }
        public int? Retailerid { get; set; }
        public int? Categoryid { get; set; }

        public virtual TblCategory Category { get; set; }
        public virtual TblRetailer Retailer { get; set; }
        public virtual ICollection<TblCart> TblCart { get; set; }
        public virtual ICollection<TblCompare> TblCompare { get; set; }
        public virtual ICollection<TblOrder> TblOrder { get; set; }
        public virtual ICollection<TblWishlist> TblWishlist { get; set; }
    }
}
