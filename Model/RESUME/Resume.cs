using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.RESUME
{
    public class Resume
    {
        public Resume()
        {
            Skills = new List<Skill>();
            Experiences = new List<Experience>();
            Educations = new List<Education>();
        }

        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Email { get; set; }
        public string? LinkedIn { get; set; }
        public string? Phone { get; set; }
        public List<Skill>? Skills { get; set; }
        public List<Experience>? Experiences { get; set; }
        public List<Education>? Educations { get; set; }
    }

    public class Skill
    {
        public string? SkillName { get; set; }
    }

    public class Experience
    {
        public string? Company { get; set; }
        public string? Position { get; set; }
        public string? Duration { get; set; }
        public string? Responsibilities { get; set; }
    }

    public class Education
    {
        public string? Institution { get; set; }
        public string? Degree { get; set; }
        public string? Year { get; set; }
    }
}