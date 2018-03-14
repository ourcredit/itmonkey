using AutoMapper;

namespace ItMonkey.Jobs.Dtos.LTMAutoMapper
{
    using ItMonkey.Models;

    /// <summary>
    /// 配置Job的AutoMapper
    /// </summary>
    internal static class CustomerJobMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //    configuration.CreateMap <Job, JobDto>();
            configuration.CreateMap<Job, JobListDto>();
            configuration.CreateMap<JobEditDto, Job>();
            // configuration.CreateMap<CreateJobInput, Job>();
            //        configuration.CreateMap<Job, GetJobForEditOutput>();
        }
    }
}