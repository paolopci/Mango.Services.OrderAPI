using AutoMapper;
using Mango.Services.OrderAPI.Models;
using Mango.Services.OrderAPI.Models.Dto;


namespace Mango.Services.OrderAPI

{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                // Nota: qui abbiamo il problema che nella tabella OrderHeaderDto abbiamo il campo OrderTotal mentre nella tabella 
                // CartHeaderDto abbiamo il campo CarTotal che è lo stesso ma con nomi diversi quindi 
                // devo segnarlo con AutoMapper
                config.CreateMap<OrderHeaderDto, CartHeaderDto>()
                    .ForMember(dest => dest.CartTotal,
                        u =>
                            u.MapFrom(src => src.OrderTotal)).ReverseMap();



                // Nota: qui abbiamo il problema che nella tabella OrderDetailsDto ho il campo ProductName 'string' mentre nella tabella
                // CartDetailsDto abbiamo l'oggetto ProductDto? Product quindi devo mappare la cosa con AutoMapper
                // stessa cosa con il campo Price sempre nella tabella CartDetailsDto che lo devo mappare 

                config.CreateMap<CartDetailsDto, OrderDetailsDto>()
                    .ForMember(dest => dest.ProductName, u
                    => u.MapFrom(src => src.Product.Name))
                    .ForMember(dest => dest.Price, u
                    => u.MapFrom(src => src.Product.Price));


                // qui mappo le tabelle del DB con quello del Dto
                config.CreateMap<OrderDetailsDto, CartDetailsDto>();
                config.CreateMap<OrderHeader, OrderHeaderDto>().ReverseMap();
                config.CreateMap<OrderDetailsDto, OrderDetails>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
