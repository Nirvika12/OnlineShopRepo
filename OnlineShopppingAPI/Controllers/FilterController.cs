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
    public class FilterController : ControllerBase
    {
        private readonly OnlineShopdbContext _context;

        public FilterController(OnlineShopdbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("FilterByCategory")]
        public IActionResult GetCategory(string cname)
        {
            var res = (
                from p in _context.TblProduct
                join r in _context.TblRetailer on p.Retailerid equals r.Retailerid
                join ct in _context.TblCategory on p.Categoryid equals ct.Categoryid
                where p.Productstatus == "accepted" && r.Approved == "accepted" && ct.Categoryname == cname
                select new
                {
                    p.Productname,
                    p.Productprice,
                    p.Productquantity,
                    p.Productdescription,
                    p.Productimage1
                }
                ).ToList();
            return Ok(res);

        }

        [HttpGet]
        [Route("FilterByBrandOnCategory")]
        public IActionResult GetBrandOnCategory(string cname)
        {
            var res = (
                from p in _context.TblProduct
                join r in _context.TblRetailer on p.Retailerid equals r.Retailerid
                join ct in _context.TblCategory on p.Categoryid equals ct.Categoryid
                where p.Productstatus == "accepted" && r.Approved == "accepted" && ct.Categoryname == cname
                select new
                {
                    p.Productbrand
                }
                ).ToList();
            return Ok(res);

        }

        [HttpGet]
        [Route("FilterByPriceAndCategory")]
        public IActionResult GetPriceAndCategory(string price, string cname)
        {
            var prices = price.Split("-");
            var lower = Convert.ToInt32(prices[0]);
            var upper = Convert.ToInt32(prices[1]);
            var res = (
                        from pr in _context.TblProduct
                        join r in _context.TblRetailer on pr.Retailerid equals r.Retailerid
                        join tc in _context.TblCategory on pr.Categoryid equals tc.Categoryid
                        where pr.Productstatus == "accepted" &&
                        r.Approved == "accepted" && pr.Productprice > lower && pr.Productprice <= upper
                        && tc.Categoryname == cname
                        select new
                        {
                            pr.Productname,
                            pr.Productprice,
                            pr.Productquantity,
                            pr.Productdescription,
                            pr.Productimage1
                        }
                ).ToList();
            return Ok(res);
        }

        [HttpGet]
        [Route("FilterByCategoryAndBrand")]
        public IActionResult GetPriceCategoryAndBrand(string cname, string bname)
        {

            var res = (
                        from pr in _context.TblProduct
                        join r in _context.TblRetailer on pr.Retailerid equals r.Retailerid
                        join tc in _context.TblCategory on pr.Categoryid equals tc.Categoryid
                        where pr.Productstatus == "accepted" &&
                        r.Approved == "accepted" && tc.Categoryname == cname && pr.Productbrand == bname
                        select new
                        {
                            pr.Productname,
                            pr.Productprice,
                            pr.Productquantity,
                            pr.Productdescription,
                            pr.Productimage1
                        }
                ).ToList();
            return Ok(res);
        }

        [HttpGet]
        [Route("FilterByPriceCategoryBrand")]
        public IActionResult GetPriceCategoryBrand(string price, string cname, string bname)
        {
            var prices = price.Split("-");
            var lower = Convert.ToInt32(prices[0]);
            var upper = Convert.ToInt32(prices[1]);
            var res = (
                        from pr in _context.TblProduct
                        join r in _context.TblRetailer on pr.Retailerid equals r.Retailerid
                        join tc in _context.TblCategory on pr.Categoryid equals tc.Categoryid
                        where pr.Productstatus == "accepted" &&
                        r.Approved == "accepted" && pr.Productprice > lower && pr.Productprice <= upper
                        && tc.Categoryname == cname && pr.Productbrand == bname
                        select new
                        {
                            pr.Productname,
                            pr.Productprice,
                            pr.Productquantity,
                            pr.Productdescription,
                            pr.Productimage1
                        }
                ).ToList();
            return Ok(res);
        }

        [HttpGet]
        [Route("SortByPrice")]
        public IActionResult GetBySort()
        {
            var res = (
                        from pr in _context.TblProduct
                        join r in _context.TblRetailer on pr.Retailerid equals r.Retailerid
                        where pr.Productstatus == "accepted" &&
                       r.Approved == "accepted"
                        orderby (pr.Productprice)
                        select new
                        {
                            pr.Productname,
                            pr.Productprice,
                            pr.Productquantity,
                            pr.Productdescription,
                            pr.Productimage1
                        }
                    ).ToList();
            return Ok(res);
        }

        [HttpGet]
        [Route("SortByPriceDesc")]
        public IActionResult GetBySortDesc()
        {
            var res = (
                        from pr in _context.TblProduct
                        join r in _context.TblRetailer on pr.Retailerid equals r.Retailerid
                        where pr.Productstatus == "accepted" &&
                        r.Approved == "accepted"
                        orderby (pr.Productprice) descending
                        select new
                        {
                            pr.Productname,
                            pr.Productprice,
                            pr.Productquantity,
                            pr.Productdescription,
                            pr.Productimage1
                        }
                    ).ToList();
            return Ok(res);
        }

        [HttpGet]
        [Route("SortByProduct")]
        public IActionResult GetBySortProduct()
        {
            var res = (
                        from pr in _context.TblProduct
                        join r in _context.TblRetailer on pr.Retailerid equals r.Retailerid
                        where pr.Productstatus == "accepted" &&
                        r.Approved == "accepted"
                        orderby (pr.Productname)
                        select new
                        {
                            pr.Productname,
                            pr.Productprice,
                            pr.Productquantity,
                            pr.Productdescription,
                            pr.Productimage1
                        }
                    ).ToList();
            return Ok(res);
        }

        [HttpGet]
        [Route("SortByProductDesc")]
        public IActionResult GetBySortProductDesc()
        {
            var res = (
                        from pr in _context.TblProduct
                        join r in _context.TblRetailer on pr.Retailerid equals r.Retailerid
                        where pr.Productstatus == "accepted" &&
                        r.Approved == "accepted"
                        orderby (pr.Productname) descending
                        select new
                        {
                            pr.Productname,
                            pr.Productprice,
                            pr.Productquantity,
                            pr.Productdescription,
                            pr.Productimage1
                        }
                    ).ToList();
            return Ok(res);
        }
    }
}
