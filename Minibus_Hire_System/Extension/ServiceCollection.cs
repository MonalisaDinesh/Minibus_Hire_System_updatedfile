using Microsoft.Extensions.DependencyInjection;
using Minibus_Hire_System.Interfaces;
using Minibus_Hire_System.Services;

namespace Minibus_Hire_System.Extension
{
    public static class ServiceCollection
    {
        public static void AddServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseService, DatabaseService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IEncryptPasswordService, EncryptPasswordService>();
            services.AddScoped<ISecurityService, SecurityService>();
        }
    }
}
