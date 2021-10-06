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
    public class AdminsController : ControllerBase
    {
        private readonly OnlineShopdbContext _context;
        public AdminsController(OnlineShopdbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Admins);
        }


        [HttpPost("AdminLogin")]
        public IActionResult AdminLogin(Admins admin)
        {
            var result = _context.Admins.Where(u => u.Email == admin.Email && u.Password == admin.Password).FirstOrDefault();
            if (result != null)
            {
                return Ok(new { status = "successful" });
            }
            return Ok(new { status = "unsuccessful" });
        }

        [HttpGet("GetAllRetailers")]
        public IActionResult GetAllRetailers()
        {
            var retailers =(from r in _context.TblRetailer
                            select r).ToList();

            return Ok(retailers);
        }


        [HttpPut("ApproveRetailer")]
        public IActionResult ApproveRetailer(int retailerid)
        {

            var updatequery = _context.TblRetailer
              .Where(x => x.Retailerid == retailerid && x.Approved == "pending")
              .FirstOrDefault();
            updatequery.Approved = "accepted";
            _context.SaveChanges();
            return Ok(updatequery);
        }

        [HttpPut]
        [Route("RemoveRetailer")]
        public IActionResult RemoveRetailer(int retailerid)
        {
            var product = _context.TblRetailer.Where(x => x.Retailerid == retailerid).FirstOrDefault();
            _context.Remove(product);
            _context.SaveChanges();
            return Ok(_context.TblRetailer);
        }


        [HttpGet("GetCategories")]
        public IActionResult GetCategories()
        {
            var categories = (from c in _context.TblCategory
                              select c).ToList();

            return Ok(categories);
        }

        [HttpGet("GetPendingProducts")]
        public IActionResult GetPendingProducts()
        {
            var pendingproducts = (from p in _context.TblProduct
                                   join r in _context.TblRetailer on p.Retailerid equals r.Retailerid
                                   join ct in _context.TblCategory on p.Categoryid equals ct.Categoryid
                                   where p.Productstatus != "rejected" && r.Approved == "accepted" &&
                                   (p.Productnotification == "add" || p.Productnotification == "updated" || p.Productnotification == "remove")
                                   select new
                                   {
                                       p.Productid,
                                       p.Productname,
                                       p.Productimage1,
                                       p.Productdescription,
                                       p.Productprice,
                                       p.Productquantity,
                                       p.Productbrand,
                                       p.Productstatus,
                                       p.Productnotification,
                                       ct.Categoryname,
                                       r.Retailerid,
                                       r.Retailername,
                                       r.Retaileremail,
                                   }).ToList();


            return Ok(pendingproducts);
        }
        [HttpPut("ApproveProduct")]
        public IActionResult ApproveProduct(int productid)
        {

            var updatequery1 = _context.TblProduct
              .Where(x => x.Productid == productid && x.Productstatus == "pending")
              .FirstOrDefault();
            updatequery1.Productstatus = "accepted";
            _context.SaveChanges();
            return Ok(updatequery1);
        }

        [HttpPut]
        [Route("RejectProduct")]
        public IActionResult RejectProduct(int productid)
        {
            var product = _context.TblProduct.Where(x => x.Productid == productid).FirstOrDefault();

            product.Productstatus = "rejected";
            _context.Remove(product);
            _context.SaveChanges();
            return Ok(new { status = "rejected" });
        }
    }
}
