using AutoMapper;
using JobsBackend.Core.Dtos.Company;
using JobsBackend.Core.Dtos.Job;
using JobsBackend.Models;

namespace JobsBackend.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile()
        {
            // Company
            CreateMap<CompanyCreateDto, Company>();
            CreateMap<Company, CompanyGetDto>();
            // Job
            CreateMap<JobCreateDto, Job>();
            CreateMap<Job, JobGetDto>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));
            // Candidate
        }
    }
}
