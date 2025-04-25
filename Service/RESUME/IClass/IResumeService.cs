using Model.RESUME;
using Model.USER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RESUME.IClass
{
    public interface IResumeService
    {
        Task<Response> SaveCompleteResume(Resume resume);
    }
}
