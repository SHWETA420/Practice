using Microsoft.AspNetCore.Mvc;
using Model.RESUME;
using Service.RESUME.IClass;
using System.Threading.Tasks;

namespace MVCProject.Controllers.RESUME
{
    public class ResumeController : Controller
    {
        private readonly IResumeService _resumeService;
        public ResumeController(IResumeService resumeService) 
        { 
            _resumeService = resumeService;
        }
        public IActionResult CreateResume()
        {
            // Initialize with one empty entry for each collection
            var model = new Resume
            {
                Skills = { new Skill() },
                Experiences = { new Experience() },
                Educations = { new Education() }
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateResume(Resume resume)
        {
            // Initialize collections if null to prevent null reference exceptions
            resume.Skills ??= new List<Skill>();
            resume.Experiences ??= new List<Experience>();
            resume.Educations ??= new List<Education>();

            if (!ModelState.IsValid)
            {
                return View(resume);
            }

            try
            {
                var response = await _resumeService.SaveCompleteResume(resume);

                if (response.Success)
                {
                    return RedirectToAction(nameof(Success));
                }

                // If the service returned unsuccessful but without throwing an exception
                ModelState.AddModelError("", response.Message ?? "Failed to save resume");
                return View(resume);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "An unexpected error occurred while saving your resume. Please try again.");
                return View(resume);
            }
        }

        public IActionResult Success()
        {
            // Retrieve the resume ID from TempData if needed
            if (TempData.TryGetValue("ResumeId", out var resumeId))
            {
                ViewBag.ResumeId = resumeId;
            }
            return View();
        }
    }
}
