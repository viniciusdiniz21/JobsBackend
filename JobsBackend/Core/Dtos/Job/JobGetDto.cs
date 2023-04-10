using JobsBackend.Core.Enums;
using JobsBackend.Models;

namespace JobsBackend.Core.Dtos.Job
{
    public class JobGetDto
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public JobLevel JobLevel { get; set; }
        public string CompanyName { get; set; }
        public long CompanyId { get; set; }
    }
}
