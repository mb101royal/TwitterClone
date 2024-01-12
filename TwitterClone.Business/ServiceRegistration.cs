using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using TwitterClone.Business.DtoValidators.TopicDtoValidators;
using TwitterClone.Business.ExternalServices.Implements;
using TwitterClone.Business.ExternalServices.Interfaces;
using TwitterClone.Business.Profiles;
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
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ITopicService, TopicService>();   
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ICommentService, CommentService>();

            return services;
        }

        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddFluentValidation(t => t.RegisterValidatorsFromAssemblyContaining<TopicCreateDtoValidator>());

            services.AddAutoMapper(typeof(TopicMappingProfile).Assembly);

            return services;
        }
    }
}
