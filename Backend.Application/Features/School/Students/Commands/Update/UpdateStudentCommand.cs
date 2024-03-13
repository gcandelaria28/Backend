using AspNetCoreHero.Results;
using Backend.Application.Interfaces.Repositories.School;
using Backend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Features.School.Students.Commands.Update
{
    public class UpdateStudentCommand : IRequest<Result<long>>
    {
        public long Id { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Result<long>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IStudentRepository _studentRepository;

            public UpdateStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
            {
                _studentRepository = studentRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<long>> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
            {
                var student = await _studentRepository.GetByIdAsync(command.Id);

                if (student == null)
                {
                    return Result<long>.Fail($"Student Not Found.");
                }
                else
                {
                    student.Name = command.Name ?? student.Name;
                    student.Address = command.Address ?? student.Address;
                    student.StudentId = (command.StudentId == 0) ? student.StudentId : command.StudentId;
                    await _studentRepository.UpdateAsync(student);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<long>.Success(student.Id);
                }
            }
        }
    }
}
