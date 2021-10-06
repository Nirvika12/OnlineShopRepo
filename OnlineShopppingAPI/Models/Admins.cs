using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineShopppingAPI.Models
{
    public partial class Admins
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal MobNo { get; set; }
        public string Password { get; set; }
        public int? UserTypeId { get; set; }

        public virtual TypeOfUsers UserType { get; set; }
    }
}
