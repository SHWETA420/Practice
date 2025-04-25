using Model.USER;
using Repository.USER.IClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.USER.Class
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DatabaseHelper _databaseHelper;
        public UsersRepository(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }
        public async Task<int> AddUsersAsync(Users user)
        {
            try
            {
                int insertedId = 0;

                using (SqlConnection conn = new SqlConnection(_databaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Adding parameters
                        cmd.Parameters.AddWithValue("@FullName", user.FullName);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@Password", user.Password);

                        // Handle Image
                        if (user.IdentityImageFile != null && user.IdentityImageFile.FileData != null && user.IdentityImageFile.FileData.Length > 0)
                        {
                            cmd.Parameters.AddWithValue("@IdentityImageFileName", user.IdentityImageFile.FileName);
                            cmd.Parameters.AddWithValue("@IdentityImageFileData", user.IdentityImageFile.FileData);
                            cmd.Parameters.AddWithValue("@IdentityImageContentType", user.IdentityImageFile.ContentType);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@IdentityImageFileName", DBNull.Value);
                            cmd.Parameters.AddWithValue("@IdentityImageFileData", DBNull.Value);
                            cmd.Parameters.AddWithValue("@IdentityImageContentType", DBNull.Value);
                        }

                        await conn.OpenAsync();
                        insertedId = Convert.ToInt32(await cmd.ExecuteScalarAsync()); // Get the newly inserted User ID
                    }
                }

                return insertedId;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
    }
}

