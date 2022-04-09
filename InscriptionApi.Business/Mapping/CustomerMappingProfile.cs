using AutoMapper;
using Ni_Soft.InscriptionApi.Business.Models;
using Ni_Soft.InscriptionApi.Data.Entities;

namespace Ni_Soft.InscriptionApi.Business.Mapping
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<CustomerEntity, Customer>().ReverseMap();
        }
    }
}