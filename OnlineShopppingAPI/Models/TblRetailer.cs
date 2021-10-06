using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineShopppingAPI.Models
{
    public partial class TblRetailer
    {
        public TblRetailer()
        {
            TblOrder = new HashSet<TblOrder>();
            TblProduct = new HashSet<TblProduct>();
        }

        public int Retailerid { get; set; }
        public string Retailername { get; set; }
        public string Retaileremail { get; set; }
        public decimal MobNo { get; set; }
        public string Gst { get; set; }
        public string Pan { get; set; }
        public string Aadhar { get; set; }
        public string Retailerpassword { get; set; }
        public string CompanyDetails { get; set; }
        public int? UserTypeId { get; set; }
        public string Approved { get; set; }

        public virtual TypeOfUsers UserType { get; set; }
        public virtual ICollection<TblOrder> TblOrder { get; set; }
        public virtual ICollection<TblProduct> TblProduct { get; set; }
    }
}
