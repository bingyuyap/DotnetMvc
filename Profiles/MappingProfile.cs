using AutoMapper;
using DotnetMvc.Models;
using DotnetMvc.ViewModels;

namespace DotnetMvc.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderViewModel, Order>();
        }
    }
}