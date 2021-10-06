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
    public class ProductsController : ControllerBase
    {
        private readonly OnlineShopdbContext _context;

        public ProductsController(OnlineShopdbContext context)
        {
            _context = context;
        }

        [Route("AllProducts")]
        [HttpGet]

        public IActionResult GetProducts()
        {
            var products = (from p in _context.TblProduct
                            join r in _context.TblRetailer on p.Retailerid equals r.Retailerid
                            join c in _context.TblCategory on p.Categoryid equals c.Categoryid
                            where p.Productstatus == "accepted" && r.Approved == "accepted" && p.Productquantity > 0
                            select new
                            {
                                p.Productid,
                                p.Productname,
                                p.Productimage1,
                                p.Productdescription,
                                p.Productprice,
                                p.Productquantity,
                                p.Productnotification,
                                p.Productbrand,
                                c.Categoryname,
                                r.Retailerid,
                                r.Retailername,
                                r.Retaileremail
                            }).ToList();

            return Ok(products);

        }


        [Route("SearchProduct")]
        [HttpGet]
        public IActionResult SearchProduct(string search)
        {
            var products = (
                        from p in _context.TblProduct
                        join r in _context.TblRetailer on p.Retailerid equals r.Retailerid
                        join ct in _context.TblCategory on p.Categoryid equals ct.Categoryid
                        where p.Productstatus == "accepted" && r.Approved == "accepted" && p.Productquantity > 0
                        && (p.Productname.Contains(search) || p.Productdescription.Contains(search) || ct.Categoryname.Contains(search)
                        || p.Productbrand.Contains(search) || ct.Categorydescription.Contains(search))
                        select new
                        {
                            p.Productid,
                            p.Productname,
                            p.Productimage1,
                            p.Productdescription,
                            p.Productprice,
                            p.Productquantity,
                            p.Productbrand,
                            ct.Categoryname,
                            r.Retailerid,
                            r.Retailername,
                            r.Retaileremail
                        }
                ).ToList();
            return Ok(products);
        }

        [Route("GetCategory")]
        [HttpGet]

        public IActionResult GetCategory()
        {
            var categories = (
                        from ct in _context.TblCategory
                        select ct).ToList();

            return Ok(categories);
        }

    }
}
