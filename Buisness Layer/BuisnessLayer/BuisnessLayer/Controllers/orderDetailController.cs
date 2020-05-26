using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BuisnessLayer.Models;

namespace BuisnessLayer.Controllers
{
    public class orderDetailController : ApiController
    {
        private CyberShopeeEntities3 db = new CyberShopeeEntities3();

        //Constructor
        public orderDetailController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/orderDetail
        public IEnumerable<orderDetail> GetorderDetails()
        {
            return db.orderDetails.ToList();
        }

        //getOrder by userId
        //[ResponseType(typeof(orderDetail))]
        [HttpGet]
        [Route("GetorderDetailByUserId/{userId}")]
        public List<orderDetail> GetorderDetailByUserId(int userId)
        {
            List<orderDetail> orderDetailObj = new List<orderDetail>();

            
                orderDetailObj = (from obj in db.orderDetails.ToList()
                                  where obj.userId == userId
                                  select obj).ToList();
            

            return orderDetailObj;
        }

        //Post the Data to Order Details Table
        [ResponseType(typeof(orderDetail))]
        public IHttpActionResult postOrderDetails(orderDetail data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    orderDetail objOrder = db.orderDetails.Find(data.orderItemId);
                    if (objOrder == null)
                    {
                        db.orderDetails.Add(data);
                        db.SaveChanges();
                        return Ok(data);
                    }
                    else
                    {
                        return BadRequest("Order id already exist!!");
                    }
                }
            }
            catch (Exception)
            {
                throw ;
            }
            
        }

        //Dipose the db Object
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}