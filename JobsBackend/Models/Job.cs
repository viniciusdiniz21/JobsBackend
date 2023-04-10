using JobsBackend.Core.Enums;

namespace JobsBackend.Models
{
    public class Job : BaseEntity
    {
        public string Title { get; set; }
        public JobLevel JobLevel { get; set; }

        //Relations 
        public long CompanyId { get; set; }
        public Company Company { get; set; }

        public List<Candidate> Candidates { get; set; }
    }
}
