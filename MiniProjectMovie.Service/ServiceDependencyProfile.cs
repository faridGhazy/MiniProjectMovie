using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniProjectMovie.Service.Interface.Services;
using MiniProjectMovie.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectMovie.Service
{
    public class ServiceDependencyProfile
    {
        public static void Register(IConfiguration iconfiguration, IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IDbService, DbService>();
        }
    }
}
