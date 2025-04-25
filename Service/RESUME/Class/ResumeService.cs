using Model.RESUME;
using Model.USER;
using Repository.RESUME.IClass;
using Service.RESUME.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RESUME.Class
{
    public class ResumeService : IResumeService
    {
        private readonly IResumeRepository _resumeRepository;

        public ResumeService(IResumeRepository resumeRepository) 
        {
            _resumeRepository = resumeRepository;
        }
        public async Task<Response> SaveCompleteResume(Resume resume)
        {
            try
            {
                await _resumeRepository.SaveResumeAsync(resume); 
                return new Response
                {
                    Success = true,
                    Message = "Resume Added SuccessFully !!!!"
                };
            }
            catch (Exception ex) 
            {
                return new Response
                {
                    Success = false,
                    Error = ex.Message,
                    Message = "error showing somewhere!!!!"
                };
            }
        }
    }
}
