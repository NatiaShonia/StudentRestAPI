using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRestAPI.Models
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;
        public StudentRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Student>> AddStudent(Student student)
        {
            var result = await _appDbContext.Students.AddAsync(student);
            await _appDbContext.SaveChangesAsync();
            return (IEnumerable<Student>)result.Entity;
        }

        public async Task DeleteStudent(int studentId)
        {
            var result = await _appDbContext.Students.FirstOrDefaultAsync(a => a.StudentId == studentId);
            if (result != null)
            {
                _appDbContext.Students.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Student> GetStudent(int studentId)
        {
            return await _appDbContext.Students.FirstOrDefaultAsync(a => a.StudentId == studentId);
        }

       

        public Task<object> GetStudent()
        {
            throw new NotImplementedException();
        }

        public async Task<Student> GetStudentByEmail(string email)
        {
            return await _appDbContext.Students.FirstOrDefaultAsync(a=>a.Email== email);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _appDbContext.Students.ToListAsync();
        }

        public async Task<IEnumerable<Student>> Search(string name, Gender? gender)
        {
            IQueryable<Student> query = _appDbContext.Students;
            query=query.Where(a=>a.FirstName.Contains(name) || a.LastName.Contains(name));

            if(gender != null)
            {
                query=query.Where(a=>a.Gender==gender);
            }
            
            return await query.ToListAsync();

        }


        public async Task<Student> UpdateStudent(Student student)
        {
            var result=await _appDbContext.Students.FirstOrDefaultAsync(a=>a.StudentId==student.StudentId);

            if(result != null)
            {
                result.FirstName = student.FirstName;
                result.LastName = student.LastName;
                result.Email = student.Email;
                result.DateOfBirth=student.DateOfBirth;
                result.Gender=student.Gender;
                if (student.DepartmentId !=0)
                {
                    result.DepartmentId= student.DepartmentId;
                }

                result.PhotoPath=student.PhotoPath;
                await _appDbContext.SaveChangesAsync();
                return result;

            }
            return null;
        }

        Task<Student> IStudentRepository.AddStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
