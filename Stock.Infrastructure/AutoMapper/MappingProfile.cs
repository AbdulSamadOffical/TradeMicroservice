using AutoMapper;
using Trade.Domain.Entities;
using Trade.Domain.DomainEntities;
using Trade.Domain.Dtos;
using Trade.Domain.DomainModel;


namespace Trade.Infrastructure.AutoMapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile() 
        {

            CreateMap<StockProduct, StockDomain>();
            CreateMap<StockRequestDto, StockProduct>();
            CreateMap<UserDto, User>();
            CreateMap<Order, OrderDomain>();
            CreateMap<OrderDto, Order>();
            CreateMap<StockDto, StockProduct>();
         
             
        }

    }
}
