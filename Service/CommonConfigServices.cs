using Microsoft.Extensions.DependencyInjection;
using Service.RESUME.Class;
using Service.RESUME.IClass;
using Service.USER.Class;
using Service.USER.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class CommonConfigServices
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            //Register Repository dependency
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IResumeService, ResumeService>();
            services.AddScoped<IResumeTemplateService, ResumeTemplateService>();
        }
    }
}
