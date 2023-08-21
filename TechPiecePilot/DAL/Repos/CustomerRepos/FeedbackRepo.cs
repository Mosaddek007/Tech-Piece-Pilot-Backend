using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.CustomerRepos
{
    internal class FeedbackRepo : Repos, IRepos<FeedbackModel, int, FeedbackModel>
    {
        public FeedbackModel Create(FeedbackModel obj)
        {
            db.FeedbackModels.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.FeedbackModels.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<FeedbackModel> Read()
        {
            return db.FeedbackModels.ToList();
        }

        public FeedbackModel Read(int id)
        {
            return db.FeedbackModels.Find(id);
        }

        public FeedbackModel Update(FeedbackModel obj)
        {
            throw new NotImplementedException();
        }

        public FeedbackModel CustomerFeeedback(string username)
        {
            var data = db.Customers.FirstOrDefault(u => u.Username.Equals(username));
            if (data != null) return db.FeedbackModels.Find(username);
            return null;
        }
    }
}
