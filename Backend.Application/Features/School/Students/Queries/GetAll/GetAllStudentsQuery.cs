using AspNetCoreHero.Results;
using Backend.Application.Extensions;
using Backend.Application.Interfaces.Repositories.School;
using Backend.Domain.Entities.School;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Features.School.Students.Queries.GetAll
{
    public class GetAllStudentsQuery : IRequest<PaginatedResult<GetAllStudentsResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllStudentsQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GGetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, PaginatedResult<GetAllStudentsResponse>>
    {
        private readonly IStudentRepository _repository;

        public GGetAllStudentsQueryHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<GetAllStudentsResponse>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetAllStudentsResponse>> expression = e => new GetAllStudentsResponse
            {
                Id = e.Id,
                StudentId = e.StudentId,
                Name = e.Name,
                Address = e.Address,
            };
            var paginatedList = await _repository.Student
                .Select(expression)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }
    }
}
