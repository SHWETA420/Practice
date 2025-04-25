using Microsoft.Extensions.DependencyInjection;
using Repository.RESUME.Class;
using Repository.RESUME.IClass;
using Repository.USER.Class;
using Repository.USER.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class CommonConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IResumeRepository, ResumeRepository>();
        }
    }
}
