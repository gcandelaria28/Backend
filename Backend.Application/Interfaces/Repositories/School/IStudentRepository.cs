using Backend.Domain.Entities.Catalog;
using Backend.Domain.Entities.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Interfaces.Repositories.School
{
    public interface IStudentRepository
    {
        IQueryable<Student> Student { get; }

        Task<List<Student>> GetListAsync();
        Task<Student> GetByIdAsync(long student_Id);

        Task<long> InsertAsync(Student student);

        Task UpdateAsync(Student student);

        Task DeleteAsync(Student student);
    }
}
