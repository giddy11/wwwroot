using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wwwroot.FileStorage
{
    internal class FlatFileStorageRegistration
    {
        public static IUnityContainer AddFlatFileStorageService(this IUnityContainer container)
        {
            return container.RegisterType<IFileStorage, FlatFileStorage>();
        }

        public static IServiceCollection AddFlatFileStorageService(this IServiceCollection services)
        {
            return services.AddScoped<IFileStorage, FlatFileStorage>();
        }
    }
}
