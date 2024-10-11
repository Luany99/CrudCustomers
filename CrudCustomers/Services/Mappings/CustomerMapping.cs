using AutoMapper;
using CrudCustomers.Models.DTOs;
using CrudCustomers.Models;

public class CustomerMapping : Profile
{
    public CustomerMapping()
    {
        CreateMap<CustomerDto, Customer>()
            .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
            .ForMember(dest => dest.Phones, opt => opt.MapFrom(src => src.Phones))
            .ForMember(dest => dest.Emails, opt => opt.MapFrom(src => src.Emails))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<Customer, CustomerDto>()
            .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
            .ForMember(dest => dest.Phones, opt => opt.MapFrom(src => src.Phones))
            .ForMember(dest => dest.Emails, opt => opt.MapFrom(src => src.Emails));

        CreateMap<ViaCepDto, AddressDto>()
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Logradouro))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Localidade))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Uf))
            .ForMember(dest => dest.Neighborhood, opt => opt.MapFrom(src => src.Bairro))
            .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Cep))
            .ForMember(dest => dest.Number, opt => opt.Ignore());

        CreateMap<AddressDto, Address>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => true));

        CreateMap<PhoneDto, Phone>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => true));

        CreateMap<EmailDto, Email>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => true)); 
    }
}
