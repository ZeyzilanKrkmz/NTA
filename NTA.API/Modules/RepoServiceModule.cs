using System.Reflection;
using Autofac;
using NTA.Core.Repositories;
using NTA.Core.Repositories.Repositories;
using NTA.Core.Repositories.UnitOfWorks;
using NTA.Core.Services;
using NTA.Core.UnitOfWorks;
using NTA.Service.Mappings;
using NTA.Service.Services;
using Module = Autofac.Module;

namespace NTA.Modules;

public class RepoServiceModule:Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
        builder.RegisterGeneric(typeof(NTA.Service.Services.Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();
        builder.RegisterType<UnitOfWorks>().As<IUnitOfWorks>();

        builder.RegisterType<TokenHandler>().As<ITokenHandler>();

        var apiAssembly = Assembly.GetExecutingAssembly();
        var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
        var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));
        
        builder.RegisterAssemblyTypes(apiAssembly,repoAssembly,serviceAssembly).
            Where(x=>x.Name.EndsWith("Repository")).
            AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(apiAssembly,repoAssembly,serviceAssembly).
            Where(x=>x.Name.EndsWith("Service")).
            AsImplementedInterfaces().InstancePerLifetimeScope();
        
        
    }
}