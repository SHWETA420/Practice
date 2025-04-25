using Model.RESUME;
using Repository.RESUME.IClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RESUME.Class
{
    public class ResumeRepository : IResumeRepository
    {
        private readonly DatabaseHelper _databaseHelper;
        public ResumeRepository(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }
        public async Task<int> SaveResumeAsync(Resume resume)
        {
            using (var connection = new SqlConnection(_databaseHelper.GetConnectionString()))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("sp_InsertResume", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the main resume
                    command.Parameters.AddWithValue("@Name", resume.Name ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Title", resume.Title ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Email", resume.Email ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@LinkedIn", resume.LinkedIn ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Phone", resume.Phone ?? (object)DBNull.Value);

                    // Create and add Skills table-valued parameter
                    var skillsTable = new DataTable();
                    skillsTable.Columns.Add("SkillName", typeof(string));
                    foreach (var skill in resume.Skills ?? new List<Skill>())
                    {
                        skillsTable.Rows.Add(skill.SkillName);
                    }
                    command.Parameters.Add(new SqlParameter("@Skills", skillsTable)
                    {
                        TypeName = "SkillType",
                        SqlDbType = SqlDbType.Structured
                    });

                    // Create and add Experiences table-valued parameter
                    var experiencesTable = new DataTable();
                    experiencesTable.Columns.Add("Company", typeof(string));
                    experiencesTable.Columns.Add("Position", typeof(string));
                    experiencesTable.Columns.Add("Duration", typeof(string));
                    experiencesTable.Columns.Add("Responsibilities", typeof(string));
                    foreach (var exp in resume.Experiences ?? new List<Experience>())
                    {
                        experiencesTable.Rows.Add(
                            exp.Company,
                            exp.Position,
                            exp.Duration,
                            exp.Responsibilities
                        );
                    }
                    command.Parameters.Add(new SqlParameter("@Experiences", experiencesTable)
                    {
                        TypeName = "ExperienceType",
                        SqlDbType = SqlDbType.Structured
                    });

                    // Create and add Educations table-valued parameter
                    var educationsTable = new DataTable();
                    educationsTable.Columns.Add("Institution", typeof(string));
                    educationsTable.Columns.Add("Degree", typeof(string));
                    educationsTable.Columns.Add("Year", typeof(string));
                    foreach (var edu in resume.Educations ?? new List<Education>())
                    {
                        educationsTable.Rows.Add(
                            edu.Institution,
                            edu.Degree,
                            edu.Year
                        );
                    }
                    command.Parameters.Add(new SqlParameter("@Educations", educationsTable)
                    {
                        TypeName = "EducationType",
                        SqlDbType = SqlDbType.Structured
                    });

                    // Execute the stored procedure and return the ResumeId
                    var result = await command.ExecuteScalarAsync();
                    return Convert.ToInt32(result);
                }
            }
        }
    }
}

