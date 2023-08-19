using BLL.DTOs.AdminDTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AdminServices.Services
{
    public class ProductServices
    {
        //GET All Products
        public static List<ProductDTO> GetProduct()
        {
            var data = DAL.DataAccessLayer.N_ProductData().Read();
            var returndata = new List<ProductDTO>();
            foreach (var item in data)
            {
                var data1 = new ProductDTO()
                {
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    ProductPicture = item.ProductPicture,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    Date = item.Date,
                    ProductStatus = item.ProductStatus,
                    CategoryID = item.CategoryID
                };
                returndata.Add(data1);

            }
            return returndata;

        }
        //GET Product By ID
        public static ProductDTO GetProductById(int id)
        {
            var data = DAL.DataAccessLayer.N_ProductData().Read(id); 
            //var productItem = data.Find(item => item.ProductID == id); 
            if (data != null)
            {
                var product = new ProductDTO()
                {
                    ProductID= data.ProductID,
                    ProductName = data.ProductName,
                    ProductPicture = data.ProductPicture,
                    Quantity = data.Quantity,
                    Price = data.Price,
                    Date = data.Date,
                    ProductStatus = data.ProductStatus,
                    CategoryID = data.CategoryID
                };
                return product;
            }
            return null;
        }

        //POST Product
        public static ProductDTO CreateProduct(ProductDTO obj)
        {


            var data1 = new ProductModel()
            {
                ProductName = obj.ProductName,
                ProductPicture = obj.ProductPicture,
                Quantity = obj.Quantity,
                Price = obj.Price,
                Date = obj.Date,
                ProductStatus = obj.ProductStatus,
                CategoryID = obj.CategoryID

            };
            var data = DAL.DataAccessLayer.N_ProductData().Create(data1);

            if (data != null)
            {
                obj.ProductID = data.ProductID;
                return obj;
            }
            else
            {
                return null;
            }

        }

        //Product Delete
        public static bool DeleteProduct(int id)
        {

            var data = DAL.DataAccessLayer.N_ProductData().Delete(id);

            return data;

        }

        // Update product
        public static ProductDTO UpdateProduct(ProductDTO obj)
        {
            var data1 = new ProductModel()
            {ProductID = obj.ProductID,
                ProductName = obj.ProductName,
                ProductPicture = obj.ProductPicture,
                Quantity = obj.Quantity,
                Price = obj.Price,
                Date = obj.Date,
                ProductStatus = obj.ProductStatus,
                CategoryID = obj.CategoryID

            };
            var data = DAL.DataAccessLayer.N_ProductData().Update(data1);

            if (data != null)
            {
                return obj;
            }
            else
            {
                return null;
            }

        }
    }
}
