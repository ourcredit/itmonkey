using AutoMapper;

namespace ItMonkey.Shufflings.Dtos.LTMAutoMapper
{
    using ItMonkey.Models;

    /// <summary>
    /// 配置Shuffling的AutoMapper
    /// </summary>
    internal static class CustomerShufflingMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //    configuration.CreateMap <Shuffling, ShufflingDto>();
            configuration.CreateMap<Shuffling, ShufflingListDto>();
            configuration.CreateMap<ShufflingEditDto, Shuffling>();
            // configuration.CreateMap<CreateShufflingInput, Shuffling>();
            //        configuration.CreateMap<Shuffling, GetShufflingForEditOutput>();
        }
    }
}