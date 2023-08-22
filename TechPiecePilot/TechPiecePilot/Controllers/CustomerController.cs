using BLL.DTOs.Customer;
using BLL.Services;
using BLL.Services.CustomerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TechPiecePilot.Authenticate;

namespace TechPiecePilot.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CustomerController : ApiController
    {
        //GET all Customers
        [HttpGet]
        [Route("api/customers")]
        public HttpResponseMessage Customers()
        {
            try
            {
                var data = CustomerService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }


        //Add Customer
        [HttpPost]
        [Route("api/customers/add")]
        public HttpResponseMessage CustomersAdd(CustomerDTO customer)
        {
            try
            {
                var data = CustomerService.Insert(customer);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }

       // [Logged]
        [HttpGet]
        [Route("api/customers/{username}")]
        public HttpResponseMessage Customers(string username)
        {
            try
            {
                var data = CustomerService.Get(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }


        //Update Customer
        [HttpPost]
        [Route("api/customers/update/{username}")]
        public HttpResponseMessage CustomersUpdate(CustomerDTO username)
        {
            try
            {
                var data = CustomerService.Update(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }
        //Delete Customer
        [HttpPost]
        [Route("api/customers/{username}/delete")]
        public HttpResponseMessage CustomersDelete(string username)
        {
            try
            {
                var data = CustomerService.Delete(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }

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
        // Customer can See cart
        [HttpGet]
        [Route("api/Customer/cartlist/{username}")]
        public HttpResponseMessage getCartByUserName(string username)
        {
            // try
            //{
            var data = CartServices.GetCartByUserName(username);
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

        //Customer can  AddFeedBack
        [HttpPost]
        [Route("api/customers/{username}/AddFeedback")]
        public HttpResponseMessage AddFeedback(FeedbackDTO feedback, string username)
        {
            try
            {
                var data = FeedbackService.Insert(feedback, username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }
        //Customer can  GetFeedBack by Username
        [HttpGet]
        [Route("api/customers/{username}/feedbacks")]
        public HttpResponseMessage CustomerFeedback(string username)
        {
            try
            {
                var data = CustomerService.CustomerFeedbacks(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }





        //Customer can  Delete FeedBack by Username
        [HttpPost]
        [Route("api/customers/{username}/feedback/delete")]
        public HttpResponseMessage CustomersfeedbackDelete(string username)
        {
            try
            { 
                var data = CustomerService.FeedbackDelete(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }

        private HttpResponseMessage HttpNotFound()
        {
            throw new NotImplementedException();
        }

    }
}
