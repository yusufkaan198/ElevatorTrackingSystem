using ETS.Business.Implementations;
using ETS.Business.Interfaces;
using ETS.Business.MapperProfiles;
using ETS.DataAccess.EF.Repositories;
using ETS.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.Business
{
    public static class ServicesCollectionExtentions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IStructureBs, StructureBs>();
            services.AddScoped<IStructureRepository, StructureRepository>();
            services.AddAutoMapper(typeof(StructureMapperProfile).Assembly);
        }
    }
}
