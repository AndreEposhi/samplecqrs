using AutoMapper;
using SampleCqrs.Application.AutoMapper.Profiles;

namespace SampleCqrs.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<ModelToViewModelProfile>();
                config.AddProfile<ViewModelToModelProfile>();
            });
        }
    }
}