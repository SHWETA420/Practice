using Model.RESUME;
using Service.RESUME.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RESUME.Class
{
    public class ResumeTemplateService : IResumeTemplateService
    {
            public List<ResumeTemplate> GetTemplates()
            {
                return new List<ResumeTemplate>
        {
            new ResumeTemplate
            {
                Id = 1,
                Name = "IT Professional",
                Description = "Template for software developers and IT specialists",
                Category = "IT",
                PreviewImagePath = "/images/templates/it-template.jpg",
                Template = CreateItResumeTemplate()
            },
            new ResumeTemplate
            {
                Id = 2,
                Name = "Marketing Professional",
                Description = "Template for marketing and communications",
                Category = "Marketing",
                PreviewImagePath = "/images/templates/marketing-template.jpg",
                Template = CreateMarketingResumeTemplate()
            }
        };
            }

            private Resume CreateItResumeTemplate()
            {
                return new Resume
                {
                    Name = "John Smith",
                    Title = "Senior Software Engineer",
                    Email = "john.smith@example.com",
                    LinkedIn = "linkedin.com/in/johnsmith",
                    Phone = "(123) 456-7890",
                    Skills = new List<Skill>
            {
                new Skill { SkillName = "C#/.NET" },
                new Skill { SkillName = "ASP.NET Core" }
            },
                    Experiences = new List<Experience>
            {
                new Experience
                {
                    Company = "Tech Solutions Inc.",
                    Position = "Senior Developer",
                    Duration = "2018-Present",
                    Responsibilities = "Developed enterprise applications"
                }
            },
                    Educations = new List<Education>
            {
                new Education
                {
                    Institution = "University of Technology",
                    Degree = "BSc Computer Science",
                    Year = "2015"
                }
            }
                };
            }

            private Resume CreateMarketingResumeTemplate()
            {
                return new Resume
                {
                    Name = "Sarah Johnson",
                    Title = "Marketing Manager",
                    Email = "sarah.j@example.com",
                    LinkedIn = "linkedin.com/in/sarahjohnson",
                    Phone = "(987) 654-3210",
                    Skills = new List<Skill>
            {
                new Skill { SkillName = "Digital Marketing" },
                new Skill { SkillName = "SEO" }
            },
                    Experiences = new List<Experience>
            {
                new Experience
                {
                    Company = "Global Brands Co.",
                    Position = "Marketing Manager",
                    Duration = "2019-Present",
                    Responsibilities = "Led digital campaigns"
                }
            },
                    Educations = new List<Education>
            {
                new Education
                {
                    Institution = "State University",
                    Degree = "BBA Marketing",
                    Year = "2016"
                }
            }
                };
            }
    }
}
