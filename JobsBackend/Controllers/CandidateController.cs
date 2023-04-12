using AutoMapper;
using JobsBackend.Core.Context;
using JobsBackend.Core.Dtos.Candidate;
using JobsBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.IO;


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
            var pdfFile = "application/pdf";

            if(formFile.Length > fiveMegaByte || formFile.ContentType != pdfFile)
            {
                return BadRequest("File type not allowed");
            }

            var resumeUrl = Guid.NewGuid().ToString() + ".pdf";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdf", resumeUrl);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            var newCandidate = _mapper.Map<Candidate>(dto);
            newCandidate.ResumeUrl = resumeUrl;
            await _context.Candidates.AddAsync(newCandidate);
            await _context.SaveChangesAsync();

            return Ok(newCandidate);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CandidateGetDto>>> GetCandidates()
        {
            var candidates = await _context.Candidates.Include(c => c.Job).ToListAsync();
            var convertedCandidates = _mapper.Map<IEnumerable<CandidateGetDto>>(candidates);

            return Ok(convertedCandidates);
        }

        [HttpGet]
        [Route("download/{url}")]
        public IActionResult DownloadPdfFile (string url)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdf", url);

            if (!System.IO.File.Exists(url))
            {
                return NotFound("File not found");
            }

            var pdfFiles = System.IO.File.ReadAllBytes(filePath);
            var file = File(pdfFiles, "application/pdf", url);
            return Ok(file);
        }
    }
}
