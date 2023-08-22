using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.AdminRepos
{
    internal class ProductRepo : Repos, IRepos<ProductModel, int, ProductModel>
    {
       public ProductModel Create(ProductModel obj)
        {
            try
            {
                db.Products.Add(obj);
                if (db.SaveChanges() > 0) return obj;
                return null;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            if(ex != null)
            {
                db.Products.Remove(ex);
                if (db.SaveChanges() > 0) return true;
                return false;
            }
            return false;
           
        }

        public List<ProductModel> Read()
        {
            return db.Products.ToList();
        }

        public ProductModel Read(int id)
        {
            return db.Products.Find(id);
        }

        public ProductModel Update(ProductModel obj)
        {
            var ex = Read(obj.ProductID);
            if (ex != null)
            {
                db.Entry(ex).CurrentValues.SetValues(obj);
                if (db.SaveChanges() > 0)
                {
                    return obj;
                }

                    return null;
            }
            
            return null;
        }
    }
}
