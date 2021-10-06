using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineShopppingAPI.Models
{
    public partial class TypeOfUsers
    {
        public TypeOfUsers()
        {
            Admins = new HashSet<Admins>();
            TblRetailer = new HashSet<TblRetailer>();
            TblUser = new HashSet<TblUser>();
        }

        public int Id { get; set; }
        public string UserType { get; set; }

        public virtual ICollection<Admins> Admins { get; set; }
        public virtual ICollection<TblRetailer> TblRetailer { get; set; }
        public virtual ICollection<TblUser> TblUser { get; set; }
    }
}
