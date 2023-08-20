using BLL.AdminServices.Services;
using BLL.DTOs;
using BLL.DTOs.AdminDTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

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
            // try
            //{
            var data = ProductServices.CreateProduct(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
            // }
            // (Exception ex)
            //
            //   return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            //}
        }
        // Admin can GET AllProducts
        [HttpGet]
        [Route("api/Admins/AllProducts")]
        public HttpResponseMessage AllProducts()
        {
            // try
            //{
            var data = ProductServices.GetProduct();
            return Request.CreateResponse(HttpStatusCode.OK, data);
            // }
            // (Exception ex)
            //
            //   return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            //}
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

            var data = ProductServices.UpdateProduct(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }


        /*// Admin can POST ADDUsers
        [HttpPost]
        [Route("api/Admins/AddUsers")]
        public HttpResponseMessage create(UserDTO obj)
        {
            // try
            //{
            var data = UserServices.CreateUser(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
            // }
            // (Exception ex)
            //
            //   return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            //}
        }

        // Admin can GET AllUsers
        
        [HttpGet]
        [Route("api/Admins/AllUsers")]
        public HttpResponseMessage AllUsers()
        {
            // try
            //{
            var data = UserServices.GetUsers();
            return Request.CreateResponse(HttpStatusCode.OK, data);
            // }
            // (Exception ex)
            //
            //   return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            //}
        }

        // Admin can GET Users By ID
        [HttpGet]
        [Route("api/Admins/{id}")]
        public HttpResponseMessage GetUsersById(int id)
        {
            var data = UserServices.GetUserByID(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return HttpNotFound();
        }
        // UpdateUser
        [HttpPost]
        [Route("api/user/update")]
        public HttpResponseMessage userUpdate(UserDTO obj)
        {
            // try
            //{
            var data = UserServices.UpdateUSer(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
            // }
            // (Exception ex)
            //
            //   return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            //}
        }
        // Delete User
        [HttpGet]
        [Route("api/Admins/DeleteUser/{id}")]
        public HttpResponseMessage DeleteUserId(int id)
        {
            var data = UserServices.DeleteUser(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return HttpNotFound();
        }*/

        private HttpResponseMessage HttpNotFound()
        {
            throw new NotImplementedException();
        }


    }
}
