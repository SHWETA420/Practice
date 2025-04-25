using Model.RESUME;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RESUME.IClass
{
    public interface IResumeRepository
    {
        Task<int> SaveResumeAsync(Resume resume);
    }
}
