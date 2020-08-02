using MediatR;
using Microsoft.Practices.Unity;
using SampleCqrs.Application.Interfaces.Cadastro;
using SampleCqrs.Application.Interfaces.Movimento;
using SampleCqrs.Application.Services.Cadastro;
using SampleCqrs.Application.Services.Movimento;
using SampleCqrs.Domain.Commands.Cadastro.Cliente;
using SampleCqrs.Domain.Commands.Handlers.Cadastro.Cliente;
using SampleCqrs.Domain.Commands.Handlers.Movimento;
using SampleCqrs.Domain.Commands.Movimento;
using SampleCqrs.Domain.Core.Responses;
using SampleCqrs.Domain.Interfaces.Repositories;
using SampleCqrs.Domain.Interfaces.Repositories.Cadastro;
using SampleCqrs.Domain.Interfaces.Repositories.Movimento;
using SampleCqrs.Domain.Interfaces.UnitOfWork;
using SampleCqrs.Domain.Queries.Cadastro.Cliente;
using SampleCqrs.Domain.Queries.Handlers.Cadastro.Cliente;
using SampleCqrs.Infra.Data.Contexts;
using SampleCqrs.Infra.Data.Helpers;
using SampleCqrs.Infra.Data.Repositories;
using SampleCqrs.Infra.Data.Repositories.Cadastro;
using SampleCqrs.Infra.Data.Repositories.Movimento;
using SampleCqrs.Infra.Data.UnitOfWork;
using System.Web.Http;
using Unity.WebApi;

namespace SampleCqrs.Infra.CrossCutting.IoC.App_Start
{
    public class UnityConfig
    {
        public static IUnityContainer RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<SampleCqrsDbContext, SampleCqrsDbContext>(new ContainerControlledLifetimeManager(),
                                                                             new InjectionConstructor(new object[]
                                                                             {
                                                                                 ConnectionHelper.GetConnectiosString()
                                                                             }));
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType<IClienteRepository, ClienteRepository>();
            container.RegisterType<IPedidoRepository, PedidoRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IClienteAppService, ClienteAppService>();
            container.RegisterType<IPedidoAppService, PedidoAppService>();
            container.RegisterType<IRequestHandler<AdicionarClienteCommand, CustomResponse>, AdicionarClienteHandler>();
            container.RegisterType<IRequestHandler<AtualizarClienteCommand, CustomResponse>, AtualizarClienteHandler>();
            container.RegisterType<IRequestHandler<RemoverClienteCommand, CustomResponse>, RemoverClienteHandler>();
            container.RegisterType<IRequestHandler<ObterClientePorIdQuery, CustomResponse>, ObterClientePorIdHandler>();
            container.RegisterType<IRequestHandler<ListarClienteQuery, CustomResponse>, ListarClienteHandler>();
            container.RegisterType<IRequestHandler<AdicionarPedidoCommand, CustomResponse>, AdicionarPedidoHandler>();

            BuildMediator(container);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            return container;
        }

        private static void BuildMediator(IUnityContainer container)
        {
            container.RegisterType<IMediator, Mediator>();
            container.RegisterInstance<SingleInstanceFactory>(type => container.Resolve(type));
            container.RegisterInstance<MultiInstanceFactory>(type => container.ResolveAll(type));
        }
    }
}