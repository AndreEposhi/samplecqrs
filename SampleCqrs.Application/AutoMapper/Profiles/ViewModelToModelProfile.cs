using AutoMapper;
using SampleCqrs.Application.ViewModels.Cadastro;
using SampleCqrs.Application.ViewModels.Movimento;
using SampleCqrs.Domain.Commands.Cadastro.Cliente;
using SampleCqrs.Domain.Commands.Movimento;

namespace SampleCqrs.Application.AutoMapper.Profiles
{
    public class ViewModelToModelProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ClienteViewModel, AdicionarClienteCommand>()
                .ConstructUsing(map => new AdicionarClienteCommand(map.Nome, map.Email));

            CreateMap<ClienteViewModel, AtualizarClienteCommand>()
                .ConstructUsing(map => new AtualizarClienteCommand(map.Id, map.Nome, map.Email));

            CreateMap<PedidoViewModel, AdicionarPedidoCommand>()
                .ConstructUsing(map => new AdicionarPedidoCommand(map.Numero, map.ClienteId));

            base.Configure();
        }
    }
}