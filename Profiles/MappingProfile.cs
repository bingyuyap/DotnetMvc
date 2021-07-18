using System.Linq;
using AutoMapper;
using DotnetMvc.Models;
using DotnetMvc.ViewModels;

namespace DotnetMvc.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(ovm => ovm.Items, 
                    opt => opt.MapFrom(o => o.OrderItems.Select(oi => oi.Item).ToList()));
            // CreateMap<OrderViewModel, Order>();
            CreateMap<OrderViewModel, Order>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.Items))
                .AfterMap((src, dest) =>
                {
                    foreach (var b in dest.OrderItems)
                    {
                        b.ItemId = src.Id;
                    }
                });
            CreateMap<Item, OrderItem>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src));
        }
    }
}