using Model.RESUME;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RESUME.IClass
{
    public interface IResumeTemplateService
    {
        List<ResumeTemplate> GetTemplates();
    }
}
