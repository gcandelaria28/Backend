using Backend.Application.Interfaces.Repositories;
using Backend.Application.Interfaces.Repositories.School;
using Backend.Domain.Entities.Catalog;
using Backend.Domain.Entities.School;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Repositories.School
{
    public class StudentRepository: IStudentRepository
    {
        private readonly IRepositoryAsync<Student> _repository;

        public StudentRepository(IRepositoryAsync<Student> repository)
        {
            _repository = repository;
        }

        public IQueryable<Student> Student => _repository.Entities;

        public async Task DeleteAsync(Student student)
        {
            await _repository.DeleteAsync(student);
        }
        public async Task<Student> GetByIdAsync(long student_Id)
        {
            return await _repository.Entities.Where(p => p.Id == student_Id).FirstOrDefaultAsync();
        }

        public async Task<List<Student>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<long> InsertAsync(Student student)
        {
            await _repository.AddAsync(student);
            return student.Id;
        }

        public async Task UpdateAsync(Student student)
        {
            await _repository.UpdateAsync(student);
        }


    }
}
