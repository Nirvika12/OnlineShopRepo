using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineShopppingAPI.Models
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblProduct = new HashSet<TblProduct>();
        }

        public int Categoryid { get; set; }
        public string Categoryname { get; set; }
        public string Categorydescription { get; set; }

        public virtual ICollection<TblProduct> TblProduct { get; set; }
    }
}
