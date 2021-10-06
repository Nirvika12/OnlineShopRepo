using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly OnlineShopdbContext _context;
        public UserController(OnlineShopdbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.TblUser);
        }


        [HttpPost("UserLogin")]
        public IActionResult UserLogin(TblUser user)
        {
            var result = _context.TblUser.Where(u => u.Useremail == user.Useremail && u.Userpassword == user.Userpassword).FirstOrDefault();
            if (result != null)
            {
                return Ok(new { status = "successful" });
            }
            return Ok(new { status = "unsuccessful" });
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(TblUser user)
        {
            var existUser = _context.TblUser.Find(user.Useremail);
            if (existUser == null)
            {
                _context.TblUser.Add(user);
                _context.SaveChanges();
                return Ok(new { status = "successful" });
            }
            else
            {
                return Ok(new { status = "unsuccessful" });
            }
        }

        [Route("GetUserDetails")]
        [HttpGet]

        public IActionResult GetUserDetails(string umail)
        {
            var userdetails = (
                    from u in _context.TblUser
                    where u.Useremail == umail
                    select u
                ).ToList();

            return Ok(userdetails);
        }

        [Route("GetUserOrders")]
        [HttpGet]

        public IActionResult GetUserOrders(string umail)
        {

            var userorders = (
                    from orders in _context.TblOrder
                    join p in _context.TblProduct on orders.Productid equals p.Productid
                    join user in _context.TblUser on orders.Useremail equals user.Useremail
                    where orders.Useremail == umail
                    select new
                    {
                        orders.Orderid,
                        orders.Orderdate,
                        orders.Orderprice,
                        orders.Orderquantity,
                        p.Productname
                    }).ToList();
            return Ok(userorders);
        }

    }
}
