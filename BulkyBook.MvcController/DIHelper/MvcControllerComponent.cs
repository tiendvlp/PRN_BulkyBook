using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.MvcControllers.CategoryMvcController;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;

namespace BulkyBook.MvcController.DIHelper
{
    public class MvcControllerComponent
    {

        public static void Inject(IServiceCollection services, IConfiguration _configuration)
        {
            services.AddScoped<CategoryMvcController>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("BulkyBook")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
