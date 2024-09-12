using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Contexts;
using Demo.DAL.Models;
using Demo.Pl.MappingProfiles;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Pl
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<MvcAppG03DbContext>(
           options =>
           { 
            options.UseSqlServer(Configuration.GetConnectionString("DeafultConnection"));
            });

            services.AddScoped<IDepartmentRepository,DepartmentRepository>();
             services.AddScoped<IEmployeeRepository,EmployeeRepository>();
			services.AddAutoMapper(M => M.AddProfile(new EmployeeProfile()));
			
            //services.AddScoped<UserManager<ApplicationUser>>();
          
		}

        
      

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Employee}/{action=Index}/{id?}");
            });
        }
    }
}
