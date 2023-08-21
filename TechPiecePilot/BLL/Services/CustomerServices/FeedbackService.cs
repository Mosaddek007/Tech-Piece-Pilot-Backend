using AutoMapper;
using BLL.DTOs.Customer;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.CustomerServices
{
    public class FeedbackService
    {
        public static List<FeedbackDTO> Get()
        {
            var data = DataAccessLayer.FeedbackData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<FeedbackModel, FeedbackDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<FeedbackDTO>>(data);
            return mapped;
        }
        public static FeedbackDTO Get(int id)
        {
            var data = DataAccessLayer.FeedbackData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<FeedbackModel, FeedbackDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<FeedbackDTO>(data);
            return mapped;
        }

        public static FeedbackDTO Insert(FeedbackDTO feedback, string username)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<FeedbackDTO, FeedbackModel>();
            });
            var mapper = new Mapper(cfg);
            var feedbacks = mapper.Map<FeedbackModel>(feedback);
            feedbacks.Username = username;
            DataAccessLayer.FeedbackData().Create(feedbacks);
            return feedback;
        }
        public static FeedbackDTO Update(FeedbackDTO feedback)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<FeedbackDTO, FeedbackModel>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<FeedbackModel>(feedback);
            DataAccessLayer.FeedbackData().Update(mapped);
            return feedback;
        }

        public static bool Delete(int id)
        {
            var data = DataAccessLayer.FeedbackData().Delete(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<FeedbackModel, FeedbackDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<bool>(data);
            return mapped;
        }
    }
}
