using AutoMapper;
using JobsBackend.Core.Dtos.Company;
using JobsBackend.Models;

namespace JobsBackend.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile()
        {
            // Company
            CreateMap<CompanyCreateDto, Company>();
            // Job

            // Candidate
        }
    }
}
