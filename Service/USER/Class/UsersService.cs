using Microsoft.AspNetCore.Http;
using Model;
using Model.USER;
using Repository.USER.IClass;
using Service.USER.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.USER.Class
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<Response> AddUsersAsync(User user)
        {
            try
            {
                var userdata = new Users
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    Password = user.Password,
                    IdentityImageFile = ProcessFileContent(user.IdentityImage)
                };
                var data = await _usersRepository.AddUsersAsync(userdata);
                return new Response { Success = true , Data = data , Message = "User Added SuccessFully"};
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
        private FileContent ProcessFileContent(IFormFile file)
        {
            if (file == null) return null;

            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return new FileContent
                {
                    FileName = file.FileName,
                    FileData = memoryStream.ToArray(),
                    ContentType = file.ContentType
                };
            }
        }
    }
}
