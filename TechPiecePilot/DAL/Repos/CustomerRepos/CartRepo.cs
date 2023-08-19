using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.CustomerRepos
{
    internal class CartRepo : Repos, IRepos<CartModel, int, CartModel>
    {
        public CartModel Create(CartModel obj)
        {
            db.CartModels.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.CartModels.Remove(ex);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public List<CartModel> Read()
        {
            return db.CartModels.ToList();
        }

        public CartModel Read(int id)
        {
            return db.CartModels.Find(id);
        }

        public CartModel Update(CartModel obj)
        {
            var ex = Read(obj.CartID);
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
