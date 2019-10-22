﻿using DDD.Application.Interfaces;
using DDD.Application.Services;
using DDD.Domain.Core.Bus;
using DDD.Domain.Interfaces;
using DDD.Infra.CrossCutting.Bus;
using DDD.Infrastruct.Data.Context;
using DDD.Infrastruct.Data.Repository;
using DDD.Infrastruct.Data.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DDD.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();


            // 注入 Application 应用层
            services.AddScoped<IStudentAppService, StudentAppService>();


            // 注入 Infra - Data 基础设施数据层
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<StudyContext>();//上下文



        }
    }
}
