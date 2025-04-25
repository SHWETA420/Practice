using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.RESUME
{
    public class ResumeTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Resume Template { get; set; }
        public string Category { get; set; }
        public string PreviewImagePath { get; set; } // Path to image in wwwroot
    }
}
