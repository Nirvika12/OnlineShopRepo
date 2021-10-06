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
    public class CartController : ControllerBase
    {
        private readonly OnlineShopdbContext _context;

        public CartController(OnlineShopdbContext context)
        {
            _context = context;
        }

        [Route("InsertIntoCart")]
        [HttpPost]

        public IActionResult InsertIntoCart(TblCart obj)
        {
            var cartProduct = _context.TblCart.Where(c => c.Useremail == obj.Useremail && c.Productid == obj.Productid).FirstOrDefault();
            var productquantity = _context.TblProduct.Where(p => p.Productid == obj.Productid)
                                  .Select(p => p.Productquantity).FirstOrDefault();
            if ((cartProduct == null && obj.Cartquantity <= productquantity) || (cartProduct != null && cartProduct.Cartquantity + obj.Cartquantity <= productquantity) && obj.Cartquantity > 0)
            {
                if (cartProduct == null)
                {
                    TblCart tc = new TblCart();
                    tc.Useremail = obj.Useremail;
                    tc.Productid = obj.Productid;
                    tc.Cartquantity = obj.Cartquantity;
                    _context.TblCart.Add(tc);
                    _context.SaveChanges();
                }
                else
                {
                    cartProduct.Cartquantity = cartProduct.Cartquantity + obj.Cartquantity;
                    _context.SaveChanges();
                }

                return Ok(new { status = "successful" });
            }
            return Ok(new { status = "unsuccessful" });

        }

        [Route("RemoveFromCart")]
        [HttpDelete]

        public IActionResult RemoveFromCart(int cartid)
        {

            TblCart tc = new TblCart();
            tc.Cartid = cartid;

            _context.TblCart.Remove(tc);
            _context.SaveChanges();
            return Ok(new { status = "successful" });
        }

        [Route("UpdateCart")]
        [HttpPut]
        public IActionResult UpdateCart(int cartid, int productid, int cartquantity)
        {
            var productquantity = _context.TblProduct.Where(p => p.Productid == productid)
                                 .Select(p => p.Productquantity).FirstOrDefault();
            if (cartquantity <= productquantity && cartquantity > 0)
            {
                var query = (
                    from tc in _context.TblCart
                    where tc.Cartid == cartid && tc.Productid == productid
                    select tc
                    );
                foreach (TblCart q in query)
                {
                    q.Cartquantity = cartquantity;
                }

                _context.SaveChanges();
                return Ok("Success");
            }
            else
            {
                return Ok("not available");
            }

        }

        [Route("CartTotal")]
        [HttpGet]
        public IActionResult GetCartTotalUser(string useremail)
        {
            var result = (
                 from tc in _context.TblCart
                 join p in _context.TblProduct on tc.Productid equals p.Productid
                 join r in _context.TblRetailer on p.Retailerid equals r.Retailerid
                 where tc.Useremail == useremail && p.Productstatus == "accepted" && r.Approved == "accepted"
                 select tc.Cartquantity * p.Productprice
                 );
            var Total = result.Sum();
            return Ok(Total);
        }

        [Route("GetCartUser")]
        [HttpGet]
        public IActionResult GetCartUser(string useremail)
        {
            var cartitems = (
                        from tc in _context.TblCart
                        join p in _context.TblProduct on tc.Productid equals p.Productid
                        join ct in _context.TblCategory on p.Categoryid equals ct.Categoryid
                        join r in _context.TblRetailer on p.Retailerid equals r.Retailerid
                        where tc.Useremail == useremail && p.Productstatus == "accepted" && r.Approved == "accepted"
                        select new
                        {
                            p.Productid,
                            p.Productname,
                            p.Productimage1,
                            p.Productdescription,
                            p.Productprice,
                            ct.Categoryname,
                            tc.Useremail,
                            tc.Cartquantity,
                            r.Retailerid,
                            r.Retailername,
                            r.Retaileremail,
                            tc.Cartid,
                            total = tc.Cartquantity * p.Productprice
                        }).ToList();

            return Ok(cartitems);
        }

        [Route("PurchaseAllProducts")]
        [HttpPost]
        public IActionResult PurchaseAllProducts(string useremail)
        {

            var result = (
                        from tc in _context.TblCart
                        join p in _context.TblProduct on tc.Productid equals p.Productid
                        join ct in _context.TblCategory on p.Categoryid equals ct.Categoryid
                        join r in _context.TblRetailer on p.Retailerid equals r.Retailerid
                        where tc.Useremail == useremail && p.Productstatus == "accepted" && r.Approved == "accepted"
                        select new
                        {
                            p.Productid,
                            p.Productname,
                            p.Productimage1,
                            p.Productdescription,
                            p.Productprice,
                            ct.Categoryname,
                            tc.Useremail,
                            tc.Cartquantity,
                            r.Retailerid,
                            r.Retailername,
                            r.Retaileremail,
                            tc.Cartid,
                            total = tc.Cartquantity * p.Productprice
                        }).ToList();

            DateTime date = DateTime.Now;
            if (result != null)
            {
                foreach (var item in result)
                {

                    TblOrder orders = new TblOrder();
                    orders.Orderdate = date;
                    orders.Useremail = item.Useremail;
                    orders.Productid = item.Productid;
                    orders.Retailerid = item.Retailerid;
                    orders.Orderquantity = item.Cartquantity;
                    orders.Orderprice = item.total;
                    _context.TblOrder.Add(orders);
                    _context.SaveChanges();

                    TblCart tc = new TblCart();
                    tc.Cartid = item.Cartid;
                    _context.TblCart.Remove(tc);
                    _context.SaveChanges();
                }
            }

            _context.SaveChanges();
            return Ok(new { status = "Success" });
        }

        [Route("QuantityIncr")]
        [HttpPost]

        public IActionResult QuantityIncr(string umail, int pid)
        {
            var quantity = (
                               from ct in _context.TblCart
                               join p in _context.TblProduct on ct.Productid equals p.Productid
                               where ct.Useremail == umail && p.Productid == pid
                               select ct
                            );

            foreach (TblCart cart in quantity)
            {
                cart.Cartquantity = cart.Cartquantity + 1;
            }
            _context.SaveChanges();

            return Ok(new { status = "Success" });

        }

        [Route("QuantityDecr")]
        [HttpPost]

        public IActionResult QuantityDecr(string umail, int pid)
        {
            var quantity = (
                               from ct in _context.TblCart
                               join p in _context.TblProduct on ct.Productid equals p.Productid
                               where ct.Useremail == umail && p.Productid == pid
                               select ct
                            );

            foreach (TblCart cart in quantity)
            {
                cart.Cartquantity = cart.Cartquantity - 1;
            }
            _context.SaveChanges();

            return Ok(new { status = "Success" });

        }
    }
}
