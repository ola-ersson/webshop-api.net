using AutoMapper;

public class AutoMap : Profile {
    public AutoMap() 
    {
        CreateMap<Order, OrderDTO>();
        CreateMap<OrderDTO, Order>();

        CreateMap<OrderRow, OrderRowDTO>();
        CreateMap<OrderRowDTO, OrderRow>();

        CreateMap<Product, ProductDTO>();
        CreateMap<ProductDTO, Product>();
    }
}