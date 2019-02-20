using Autofac;
using Web.Api.Core.Interfaces.UseCases;
using Web.Api.Core.UseCases;

namespace Web.Api.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterUserUseCase>().As<IRegisterUserUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GuestUserUseCase>().As<IGuestUserUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GuestEditUserUseCase>().As<IGuestEditUserUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GuestDeleteUserUseCase>().As<IGuestDeleteUserUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GuestUserGetUseCase>().As<IGuestUserGetUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GuestEntryUseCase>().As<IGuestEntryUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GuestEntryGetUseCase>().As<IGuestEntryGetUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<LoginUseCase>().As<ILoginUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<ExchangeRefreshTokenUseCase>().As<IExchangeRefreshTokenUseCase>().InstancePerLifetimeScope();
        }
    }
}
