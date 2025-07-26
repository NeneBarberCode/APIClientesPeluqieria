using APIClientesPeluqueria.DTOs;
using APIClientesPeluqueria.Models;
using AutoMapper;

namespace APIClientesPeluqueria.Profiles
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles() 
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(enti => enti.Cutsid ,
                opt => opt.MapFrom(src => src.haircuts.Select(ch => ch.HairCutId))) ;

            CreateMap<CustomerDTO, Customer>()
                .ForMember(ent => ent.haircuts,
                opt => opt.MapFrom(src => src.Cutsid.Select(id => new CustomerHaircut { HairCutId = id })));

            CreateMap<Customer, CustomersWithHaircutsDTO>()
                .ForMember(ent => ent.Cuts,
                opt => opt.MapFrom(src => src.haircuts.Select(ch => ch.hairCut.Name)));
            ///////////////////////////////////haircut//////////////////////////////////////
            
            CreateMap<HairCut, HaircutDTO>().ReverseMap();

            CreateMap<HairCut, HaircutsWithCustomers>()
                 .ForMember(ent => ent.Customers,
                 opt => opt.MapFrom(src => src.Customers.Select(hc => hc.Customer.Name)));
        }

    }
}
