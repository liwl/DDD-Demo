using AutoMapper;
using DDD.Application.ViewModels;
using DDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
