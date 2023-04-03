using JobsBackend.Core.Enums;

namespace JobsBackend.Core.Dtos.Company
{
    public class CompanyCreateDto
    {
        public string Name { get; set; }
        public CompanySize CompanySize { get; set; }
    }
}
