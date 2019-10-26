using DDD.Application.Interfaces;
using DDD.Application.Services;
using DDD.Domain.CommandHandlers;
using DDD.Domain.Commands;
using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Events;
using DDD.Domain.Core.Notifications;
using DDD.Domain.EventHandlers;
using DDD.Domain.Events;
using DDD.Domain.Interfaces;
using DDD.Infra.CrossCutting.Bus;
using DDD.Infrastruct.Data.Context;
using DDD.Infrastruct.Data.EventSourcing;
using DDD.Infrastruct.Data.Repository;
using DDD.Infrastruct.Data.Repository.EventSourcing;
using DDD.Infrastruct.Data.UoW;
using MediatR;
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

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<StudentRegisteredEvent>, StudentEventHandler>();
            services.AddScoped<INotificationHandler<StudentUpdatedEvent>, StudentEventHandler>();
            services.AddScoped<INotificationHandler<StudentRemovedEvent>, StudentEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterStudentCommand, bool>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateStudentCommand, bool>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveStudentCommand, bool>, StudentCommandHandler>();


            // 注入 Infra - Data 基础设施数据层
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<StudyContext>();//上下文

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

        }
    }
}
