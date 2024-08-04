using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRestAPI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
      private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository= studentRepository;
        }

        [HttpGet ("{search}")]
        public async Task<ActionResult<IEnumerable<Student>>> Search(string name, Gender? gender)
        {
            try
            {
                var result = await _studentRepository.Search(name, gender);
                if(result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
                throw;
            }
        }

        [HttpGet ("GetStudent")]

        public async Task<ActionResult> GetStudents()
        {
            try
            {
                return Ok(await _studentRepository.GetStudents());

            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
                ;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest();

                }

                var stuEM=await _studentRepository.GetStudentByEmail(student.Email);
                if(stuEM != null)
                {
                    ModelState.AddModelError("Email", "This email already in use");
                    return BadRequest(ModelState);
                }

                var createStudent=await _studentRepository.AddStudent(student);
                return CreatedAtAction("GetStudent",
                    new { id = createStudent.StudentId }, createStudent);

            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new student record");
            }
        }


        [HttpPut("{id:int}")]

        public async Task<ActionResult<Student>> UpdateStudent(int id , Student student)
        {
            try
            {
              if(id != student.StudentId)
                {
                    return BadRequest("Student ID mistmach");
                }

                var studentToUpdate = await _studentRepository.GetStudent(id);

                if(studentToUpdate == null)
                {
                    return NotFound($"Student with Id={id} not fount");
                }

                return await _studentRepository.UpdateStudent(student);
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating student record");

            }
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> DeleteStudent(int id)
        {
            try
            {
                var studentDelete = await _studentRepository.GetStudent(id);

                if(studentDelete == null)
                {
                    return NotFound($"Student with id={id} not found");
                }

                await _studentRepository.DeleteStudent(id);
                return Ok($"Student  with Id={id} deleted");
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting student record");
            }
        }



    }
}

