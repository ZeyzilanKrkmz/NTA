using AutoMapper;
using NTA.Core.DTOs;
using NTA.Core.Models;

namespace NTA.Service.Mappings;

public class MapProfile:Profile
{
    protected MapProfile()
    {
        CreateMap<Customer,CustomerDto>().ReverseMap();
        CreateMap<Department,DepartmentDto>().ReverseMap();
        CreateMap<Group,GroupDto>().ReverseMap();
        //CreatedMap<GroupInRole,GroupInRoleDto>().ReverseMap();
        CreateMap<Payment,PaymentDto>().ReverseMap();
        CreateMap<Product,ProductDto>().ReverseMap();
        CreateMap<Sale,SaleDto>().ReverseMap();
        CreateMap<User,UserDto>().ReverseMap();
    }
}


