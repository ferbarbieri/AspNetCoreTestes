using Application.Mappings;
using AutoMapper;
using AutoMapper.Configuration;
using SimpleInjector;
using System.Linq;

namespace App.WebAPI.AutoMapperConfig
{
    /// <summary>
    /// Provider do automapper
    /// </summary>
    public class MapperProvider
    {
        private readonly Container _container = DependencyResolver.ContainerFactory.Container;
        
        /// <summary>
        /// Retorna o Mapper configurado
        /// </summary>
        /// <returns></returns>
        public IMapper GetMapper()
        {
            var mce = new MapperConfigurationExpression();
            mce.ConstructServicesUsing(_container.GetInstance);

            var profiles = typeof(ApplicationMappingProfile).Assembly.GetTypes()
                .Where(t => typeof(Profile).IsAssignableFrom(t))
                .ToList();

            mce.AddProfiles(profiles);

            var mc = new MapperConfiguration(mce);
            mc.AssertConfigurationIsValid();

            IMapper m = new Mapper(mc, t => _container.GetInstance(t));

            return m;
        }
    }
}
