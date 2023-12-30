using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.DtoValidators.TopicDtoValidators;
using TwitterClone.Business.Repositories.Implements;
using TwitterClone.Business.Repositories.Interfaces;
using TwitterClone.Business.Services.Implements;
using TwitterClone.Business.Services.Interfaces;

namespace TwitterClone.Business
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITopicRepository, TopicRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITopicService, TopicService>();
            return services;
        }

        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddFluentValidation(table => table.RegisterValidatorsFromAssemblyContaining<TopicCreateDtoValidator>());
            return services;
        }
    }
}
