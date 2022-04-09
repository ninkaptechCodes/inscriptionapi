using AutoMapper;
using Ni_Soft.InscriptionApi.Business.Models;
using Ni_Soft.InscriptionApi.Contracts.Requests;
using Ni_Soft.InscriptionApi.Contracts.Responses;

namespace Ni_Soft.InscriptionApi.Contracts.Mappping
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerRequest>().ReverseMap();
            CreateMap<Customer, CustomerResponse>().ReverseMap();
        }
    }
}