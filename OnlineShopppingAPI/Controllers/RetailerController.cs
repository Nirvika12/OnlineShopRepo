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
    public class RetailerController : ControllerBase
    {
        private readonly OnlineShopdbContext _context;
        public RetailerController(OnlineShopdbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.TblRetailer);
        }
        [HttpPost("RetailerLogin")]
        public IActionResult ReatailerLogin(TblRetailer retailer)
        {
            var result = _context.TblRetailer.Where(u => u.Retaileremail == retailer.Retaileremail && u.Retailerpassword == retailer.Retailerpassword).FirstOrDefault();
            if (result != null && result.Approved == "accepted")
            {
                return Ok(new { status = "successful" });
            }
            return Ok(new { status = "unsuccessful" });
        }

        [HttpPost("RetailerRegister")]

        public IActionResult RetailerRegister(TblRetailer retailer)
        {
            try
            {
                retailer = new TblRetailer()
                {
                    Retailername = retailer.Retailername,
                    Retaileremail = retailer.Retaileremail,
                    Retailerpassword = retailer.Retailerpassword,
                    MobNo = retailer.MobNo,
                    Gst = retailer.Gst,
                    Aadhar = retailer.Aadhar,
                    Pan = retailer.Pan,
                    CompanyDetails = retailer.CompanyDetails,
                    UserTypeId = 1001,
                    Approved = "pending"

                };

                _context.TblRetailer.Add(retailer);
                _context.SaveChanges();
                return Ok(new { status = "successful" });
            }
            catch (Exception e)
            {
                return Ok(new { status = "unsuccessful" });
            }
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(string retaileremail, TblProduct product)
        {
            try
            {


                product = new TblProduct()
                {

                    Productname = product.Productname,
                    Productprice = product.Productprice,
                    Productquantity = product.Productquantity,
                    Productdescription = product.Productdescription,
                    Productbrand = product.Productbrand,
                    Categoryid = product.Categoryid,
                    Productnotification = "add",
                    Productstatus = "pending",
                    Productimage1 = "ABCD",
                    Retailerid = _context.TblRetailer.Where(r => r.Retaileremail == retaileremail).Select(r => r.Retailerid).FirstOrDefault()





                };
                _context.TblProduct.Add(product);
                _context.SaveChanges();


                return Ok(new { status = "successful" });

            }

            catch (Exception e)
            {
                return Ok(new { status = "unsuccessful" });
            }
        }
        [HttpPost("RetailerProducts")]
        public IActionResult RetailerProducts(string retaileremail)
        {
            var retailerproducts = (from p in _context.TblProduct
                                    join r in _context.TblRetailer
                                    on p.Retailerid equals r.Retailerid
                                    join c in _context.TblCategory
                                    on p.Categoryid equals c.Categoryid
                                    join r1 in _context.TblRetailer on p.Retailerid equals r1.Retailerid
                                    where r1.Retaileremail == retaileremail
                                    select new
                                    {
                                        p.Productid,
                                        p.Productname,
                                        p.Productprice,
                                        p.Productquantity,
                                        p.Productdescription,
                                        p.Productbrand,
                                        p.Productimage1,
                                        p.Productnotification,

                                        p.Productstatus,
                                        c.Categoryname
                                    }).Where(a => a.Productstatus != "rejected").ToList();
            return Ok(retailerproducts);

        }

        [HttpPut("RetailerUpdateProduct")]
        public IActionResult RetailerUpdateProduct(TblProduct product, int productid)
        {
            var updatequery1 = _context.TblProduct
              .Where(x => x.Productid == productid)
              .FirstOrDefault();
            updatequery1.Productprice = product.Productprice;
            updatequery1.Productquantity = product.Productquantity;
            updatequery1.Productbrand = product.Productbrand;
            updatequery1.Productdescription = product.Productdescription;
            updatequery1.Productnotification = "updated";
            updatequery1.Productstatus = "pending";

            _context.SaveChanges();
            return Ok(updatequery1);
        }
        [HttpPut]
        [Route("RemoveProduct")]
        public IActionResult RemoveProduct(int productid)
        {
            var updateq = _context.TblProduct.Where(a => a.Productid == productid).FirstOrDefault();
            updateq.Productnotification = "remove";
            updateq.Productstatus = "pending";
            _context.SaveChanges();
            return Ok(updateq);

        }
        [HttpGet("RetailerDetails")]
        public IActionResult GetRetailerDetails(string retaileremail)
        {

            var retailers = (
                                from r in _context.TblRetailer
                                where r.Retaileremail == retaileremail

                                select r).ToList();

            return Ok(retailers);
        }

    }
}
