using JobsBackend.Core.Enums;

namespace JobsBackend.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public CompanySize CompanySize { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
