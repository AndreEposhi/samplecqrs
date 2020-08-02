using AutoMapper;
using SampleCqrs.Application.ViewModels.Cadastro;
using SampleCqrs.Application.ViewModels.Movimento;
using SampleCqrs.Domain.Models.Cadastro;
using SampleCqrs.Domain.Models.Movimento;

namespace SampleCqrs.Application.AutoMapper.Profiles
{
    public class ModelToViewModelProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<PedidoViewModel, Pedido>();

            base.Configure();
        }
    }
}