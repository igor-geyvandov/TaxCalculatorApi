using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxService.Entities;
using TaxService.Models;
using TaxService.Services.Dtos;

namespace TaxService.MappingProfiles
{
    public class DefaultMappingProfile : Profile
    {
        public DefaultMappingProfile()
        {
            //Entities and Web API DTO mappings.
            CreateMap<TaxRateRequestDto, Location>().ReverseMap();
            CreateMap<TaxRateResponseDto, TaxRate>().ReverseMap();

            CreateMap<OrderTaxRequestDto, Order>().ReverseMap();
            CreateMap<AddressDto, Address>().ReverseMap();
            CreateMap<LineItemDto, LineItem>().ReverseMap();

            CreateMap<OrderTaxResponseDto, OrderTax>().ReverseMap();
            CreateMap<TaxDto, Tax>().ReverseMap();
            CreateMap<JurisdictionDto, Jurisdiction>().ReverseMap();
            CreateMap<BreakdownDto, Breakdown>().ReverseMap();
            CreateMap<ShippingDto, Shipping>().ReverseMap();

            //Entities and TaxJar DTO mappings.
            CreateMap<Location, TaxJarTaxRateRequestDto>().ReverseMap();
            CreateMap<TaxJarTaxRateResponseDto, TaxRate>().ReverseMap();

            CreateMap<Order, TaxJarOrderTaxRequestDto>().ReverseMap();
            CreateMap<Address, TaxJarAddressDto>().ReverseMap();
            CreateMap<LineItem, TaxJarLineItemDto>().ReverseMap();

            CreateMap<TaxJarOrderTaxResponseDto, OrderTax>().ReverseMap();
            CreateMap<TaxJarTaxDto, Tax>().ReverseMap();
            CreateMap<TaxJarJurisdictionDto, Jurisdiction>().ReverseMap();
            CreateMap<TaxJarBreakdownDto, Breakdown>().ReverseMap();
            CreateMap<TaxJarShippingDto, Shipping>().ReverseMap();
        }
    }
}
