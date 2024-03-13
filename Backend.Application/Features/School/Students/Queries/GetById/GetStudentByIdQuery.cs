using AspNetCoreHero.Results;
using AutoMapper;
using Backend.Application.Interfaces.Repositories.School;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Features.School.Students.Queries.GetById
{
    public class GetStudentByIdQuery : IRequest<Result<GetStudentByIdResponse>>
    {
        public long Id { get; set; }

        public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Result<GetStudentByIdResponse>>
        {
            private readonly IStudentRepository _studentRepository;
            private readonly IMapper _mapper;

            public GetStudentByIdQueryHandler(IStudentRepository studentRepository, IMapper mapper)
            {
                _studentRepository = studentRepository;
                _mapper = mapper;
            }

            public async Task<Result<GetStudentByIdResponse>> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
            {
                var student = await _studentRepository.GetByIdAsync(query.Id);
                var mappedStudent = _mapper.Map<GetStudentByIdResponse>(student);
                return Result<GetStudentByIdResponse>.Success(mappedStudent);
            }
        }
    }
}
