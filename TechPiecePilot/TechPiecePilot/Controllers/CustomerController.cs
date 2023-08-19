using BLL.DTOs.Customer;
using BLL.Services.CustomerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TechPiecePilot.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CustomerController : ApiController
    {
        // Customer can POST AddToCart
        [HttpPost]
        [Route("api/Customer/AddToCart")]
        public HttpResponseMessage create(CartDTO obj)
        {
            // try
            //{
            var data = CartServices.CreateCart(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
            // }
            // (Exception ex)
            //
            //   return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            //}
        }

        // Customer can Update Cart
        [HttpPost]
        [Route("api/Customer/UpdateCart")]
        public HttpResponseMessage CartUpdate(CartDTO obj)
        {
            // try
            //{
            var data = CartServices.UpdateCart(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
            // }
            // (Exception ex)
            //
            //   return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            //}
        }
        // Customer can POST AddToWishlist
        [HttpPost]
        [Route("api/Customer/AddWish")]
        public HttpResponseMessage create(WishlistDTO obj)
        {
            var data = WishlistServices.CreateWishlist(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // Customer can Get AddToWishlist
        [HttpGet]
        [Route("api/Customer/AllWishlists")]
        public HttpResponseMessage Wishlists()
        {

            var data = WishlistServices.GetWishlist();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
        // Customer can DeleteWishlist
        [HttpGet]
        [Route("api/Customer/DeleteWishlist/{id}")]
        public HttpResponseMessage DeleteWishlist(int id)
        {
            var product = WishlistServices.DeleteWishlist(id);
            if (product != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
            return HttpNotFound();
        }

        private HttpResponseMessage HttpNotFound()
        {
            throw new NotImplementedException();
        }
    }
}
