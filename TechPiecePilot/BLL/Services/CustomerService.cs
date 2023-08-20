using AutoMapper;
using BLL.DTOs;
using BLL.DTOs.Customer;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CustomerService
    {
        public static List<CustomerDTO> Get()
        {
            var data = DataAccessLayer.CustomerData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map< List < CustomerDTO >> (data);
            return mapped;
        }

        public static CustomerDTO Get(string username)
        {
            var data = DataAccessLayer.CustomerData().Read(username);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CustomerDTO>(data);
            return mapped;
        }

        public static CustomerDTO Insert(CustomerDTO customer)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CustomerDTO, Customer>();
                c.CreateMap<CustomerDTO, User>();
            });
            var mapper = new Mapper(cfg);
            var users = mapper.Map<User>(customer);
            users.UserType = "Customer";
            DataAccessLayer.UserData().Create(users);
            var customers = mapper.Map<Customer>(customer);
            DataAccessLayer.CustomerData().Create(customers);
            return customer;
        }
        public static CustomerDTO Update(CustomerDTO customer)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CustomerDTO, Customer>();
                c.CreateMap<CustomerDTO, User>();
            });
            var mapper = new Mapper(cfg);
            var users = mapper.Map<User>(customer);
            users.UserType = "Customer";
            DataAccessLayer.UserData().Update(users);
            var customers = mapper.Map<Customer>(customer);
            DataAccessLayer.CustomerData().Update(customers);
            return customer;
        }

        public static bool Delete(string username)
        {
            var data = DataAccessLayer.CustomerData().Delete(username);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<bool>(data);
            return mapped;
        }
    }
}
