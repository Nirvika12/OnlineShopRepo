using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineShopppingAPI.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblCart = new HashSet<TblCart>();
            TblCompare = new HashSet<TblCompare>();
            TblOrder = new HashSet<TblOrder>();
            TblWishlist = new HashSet<TblWishlist>();
        }

        public string Useremail { get; set; }
        public string Username { get; set; }
        public string Userphone { get; set; }
        public string Userpassword { get; set; }
        public int? UserTypeId { get; set; }

        public virtual TypeOfUsers UserType { get; set; }
        public virtual ICollection<TblCart> TblCart { get; set; }
        public virtual ICollection<TblCompare> TblCompare { get; set; }
        public virtual ICollection<TblOrder> TblOrder { get; set; }
        public virtual ICollection<TblWishlist> TblWishlist { get; set; }
    }
}
