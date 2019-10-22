using AutoMapper;
using DDD.Application.ViewModels;
using DDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
            //    .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
            //CreateMap<CustomerViewModel, UpdateCustomerCommand>()
            //    .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));


            //手动进行配置
            CreateMap<StudentViewModel, Student>()
             .ForPath(d => d.Address.Province, o => o.MapFrom(s => s.Province))
             .ForPath(d => d.Address.City, o => o.MapFrom(s => s.City))
             .ForPath(d => d.Address.County, o => o.MapFrom(s => s.County))
             .ForPath(d => d.Address.Street, o => o.MapFrom(s => s.Street))
             ;
        }
    }
}
