using AutoMapper;
using JobsBackend.Core.Context;
using JobsBackend.Core.Dtos.Candidate;
using JobsBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobsBackend.Controllers
{
    public class CandidateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CandidateController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCandidate([FromBody] CandidateCreateDto dto, IFormFile formFile)
        {
            var fiveMegaByte = 5 * 1024 * 1024;
            var pdfFile = "application/json";

            if(formFile.Length > fiveMegaByte || formFile.ContentType != pdfFile)
            {
                return BadRequest("File type not allowed");
            }

            var newCandidate = _mapper.Map<Candidate>(dto);
            await _context.Candidates.AddAsync(newCandidate);
            await _context.SaveChangesAsync();

            return Ok(newCandidate);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CandidateGetDto>>> GetCandidates()
        {
            var candidates = await _context.Candidates.ToListAsync();
            var convertedCandidates = _mapper.Map<IEnumerable<CandidateGetDto>>(candidates);

            return Ok(convertedCandidates);
        }
    }
}
