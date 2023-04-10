using JobsBackend.Core.Enums;

namespace JobsBackend.Core.Dtos.Company
{
    public class CompanyGetDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public CompanySize CompanySize { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
