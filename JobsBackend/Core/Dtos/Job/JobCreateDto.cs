using JobsBackend.Core.Enums;

namespace JobsBackend.Core.Dtos.Job
{
    public class JobCreateDto
    {
        public string Title { get; set; }
        public JobLevel JobLevel { get; set; }
        public long CompanyId { get; set; }
    }
}
