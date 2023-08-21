using BLL.AdminServices.Services;
using BLL.DTOs;
using BLL.DTOs.AdminDTOs;
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

namespace TechPiecePilot.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AdminController : ApiController
    {
        // Admin can POST ADDProducts
        [HttpPost]
        [Route("api/Admins/ADDProducts")]
        public HttpResponseMessage create(ProductDTO obj)
        {
            try
            {
            var data = ProductServices.CreateProduct(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            { 
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }
        // Admin can GET AllProducts
        [HttpGet]
        [Route("api/Admins/AllProducts")]
        public HttpResponseMessage AllProducts()
        {
            try
            {
            var data = ProductServices.GetProduct();
            return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            { 
            
             return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }

        // Admin can GET Product By ID
        [HttpGet]
        [Route("api/Admins/Products/{id}")]
        public HttpResponseMessage GetProductById(int id)
        {
            var product = ProductServices.GetProductById(id);
            if (product != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
            return HttpNotFound();
        }


        // Admin can GET DeleteProduct
        [HttpDelete]
        [Route("api/Admins/DeleteProduct/{id}")]
        public HttpResponseMessage DeleteProduct(int id)
        {
            var product = ProductServices.DeleteProduct(id);
            if (product != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
            return HttpNotFound();
        }


        // Admin can UpdateProduct
        [HttpPost]
        [Route("api/Admins/UpdateProduct")]
        public HttpResponseMessage UpdateProduct(ProductDTO obj)
        {
            try
            {
            var data = ProductServices.UpdateProduct(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }
        //admin can Update Feedback on ReplyFromAdmin       
        [HttpPost]
        [Route("api/Admins/UpdateFeedbacks/{obj}")]
        public HttpResponseMessage UpdateFeedback(FeedbackDTO obj)
        {
            try
            {
            var data = FeedbackService.Update(obj);
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
