using Microsoft.AspNetCore.Mvc;
using Model.RESUME;
using Service.RESUME.IClass;
using static Service.RESUME.Class.ResumeTemplateService;

namespace MVCProject.Controllers.RESUME
{
    public class ResumeTemplateController : Controller
    {
        private readonly IResumeTemplateService _templateService;

        public ResumeTemplateController(IResumeTemplateService templateService)
        {
            _templateService = templateService;
        }
        public ActionResult GetTemplate()
        {
            var templates = _templateService.GetTemplates();
            return View(templates);
        }

        [HttpGet]
        public ActionResult CreateFromTemplate(int id)
        {
            var template = _templateService.GetTemplates().FirstOrDefault(t => t.Id == id);
            if (template == null)
            {
                return View();
            }

            // Create a new resume based on the template
            var resume = new Resume
            {
                // Copy template structure but clear the sample data
                Title = template.Template.Title,
                Skills = template.Template.Skills.Select(s => new Skill { SkillName = "" }).ToList(),
                Experiences = template.Template.Experiences.Select(e => new Experience
                {
                    Company = "",
                    Position = "",
                    Responsibilities = ""
                }).ToList(),
                Educations = template.Template.Educations.Select(e => new Education
                {
                    Institution = "",
                    Degree = ""
                }).ToList()
            };

            ViewBag.TemplateName = template.Name;
            return View("~/Views/Resume/Create.cshtml", resume);
        }
    }
}
