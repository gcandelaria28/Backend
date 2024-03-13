using Backend.API.Controllers;
using Backend.Application.Features.Products.Commands.Create;
using Backend.Application.Features.Products.Commands.Delete;
using Backend.Application.Features.Products.Commands.Update;
using Backend.Application.Features.Products.Queries.GetAllPaged;
using Backend.Application.Features.Products.Queries.GetById;
using Backend.Application.Features.School.Students.Commands.Create;
using Backend.Application.Features.School.Students.Commands.Update;
using Backend.Application.Features.School.Students.Queries.GetAll;
using Backend.Application.Features.School.Students.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Api.Controllers.v1.School
{
    public class StudenetController : BaseApiController<StudenetController>
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
        {
            var students = await _mediator.Send(new GetAllStudentsQuery(pageNumber, pageSize));
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _mediator.Send(new GetStudentByIdQuery() { Id = id });
            return Ok(student);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateStudentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateStudentCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteStudentCommand { Id = id }));
        }
    }
}
