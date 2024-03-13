using AspNetCoreHero.Results;
using Backend.Application.Features.Products.Commands.Delete;
using Backend.Application.Interfaces.Repositories;
using Backend.Application.Interfaces.Repositories.School;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Features.School.Students.Commands.Delete
{
    internal class DeleteStudentCommand : IRequest<Result<long>>
    {
        public long Id { get; set; }

        public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Result<long>>
        {
            private readonly IStudentRepository _studentRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
            {
                _studentRepository = studentRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<long>> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
            {
                var student = await _studentRepository.GetByIdAsync(command.Id);
                await _studentRepository.DeleteAsync(student);
                await _unitOfWork.Commit(cancellationToken);
                return Result<long>.Success(student.Id);
            }
        }
    }
}
