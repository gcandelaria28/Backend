using AspNetCoreHero.Results;
using AutoMapper;
using Backend.Application.Interfaces.Repositories;
using Backend.Application.Interfaces.Repositories.School;
using Backend.Domain.Entities.Catalog;
using Backend.Domain.Entities.School;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Features.School.Students.Commands.Create
{
    public partial class CreateStudentCommand : IRequest<Result<long>>
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Result<long>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<long>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request);
            await _studentRepository.InsertAsync(student);
            await _unitOfWork.Commit(cancellationToken);
            return Result<long>.Success(student.Id);
        }
    }
}
