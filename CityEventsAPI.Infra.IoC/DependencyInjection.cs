using CityEventsAPI.Application.Mappings;
using CityEventsAPI.Application.Services;
using CityEventsAPI.Application.Services.Interfaces;
using CityEventsAPI.Domain.Authentication;
using CityEventsAPI.Domain.Repositories;
using CityEventsAPI.Infra.Data.Authentication;
using CityEventsAPI.Infra.Data.Context;
using CityEventsAPI.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CityEventsAPIDbContext>
                                    (options => options.UseSqlServer
                                        (configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services; 
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDTOMapping));
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
