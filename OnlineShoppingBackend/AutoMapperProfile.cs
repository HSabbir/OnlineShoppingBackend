using AutoMapper;
using OnlineShoppingBackend.Dtos.Order;
using OnlineShoppingBackend.Dtos.Product;
using OnlineShoppingBackend.Dtos.User;
using OnlineShoppingBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingBackend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, GetProductDto>();
            CreateMap<AddProductDto, Product>();
            CreateMap<Order2, GetOrderDto>();
            CreateMap<AddOrderDto, Order2>();
            CreateMap<User, GetUserDto>();
        }
    }
}
