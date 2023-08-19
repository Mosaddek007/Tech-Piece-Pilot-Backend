using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repos, IRepos<UserModel, int, UserModel>
    {
        public UserModel Create(UserModel obj)
        {
            try
            {
                db.UserModels.Add(obj);
                if (db.SaveChanges() > 0) return obj;
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            if (ex != null)
            {
                db.UserModels.Remove(ex);
                if (db.SaveChanges() > 0) return true;
                return false;
            }
            return false;

        }

        public List<UserModel> Read()
        {
            return db.UserModels.ToList();
        }

        public UserModel Read(int id)
        {
            return db.UserModels.Find(id);
        }

        public UserModel Update(UserModel obj)
        {
            try 
            {
                var ex = Read(obj.UserID);
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
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
