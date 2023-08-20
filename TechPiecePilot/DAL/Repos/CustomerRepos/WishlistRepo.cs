using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.CustomerRepos
{
    internal class WishlistRepo : Repos, IRepos<WishlistModel, int, WishlistModel>
    {
        public WishlistModel Create(WishlistModel obj)
        {
            try
            {
                db.WishlistModels.Add(obj);
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
            db.WishlistModels.Remove(ex);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public List<WishlistModel> Read()
        {
            return db.WishlistModels.ToList();
        }

        public WishlistModel Read(int id)
        {
            return db.WishlistModels.Find(id);
        }

        public WishlistModel Update(WishlistModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
