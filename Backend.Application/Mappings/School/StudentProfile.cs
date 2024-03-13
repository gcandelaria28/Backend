using AutoMapper;
using Backend.Application.Features.Products.Commands.Create;
using Backend.Application.Features.Products.Queries.GetAllCached;
using Backend.Application.Features.Products.Queries.GetAllPaged;
using Backend.Application.Features.Products.Queries.GetById;
using Backend.Application.Features.School.Students.Commands.Create;
using Backend.Application.Features.School.Students.Queries.GetAll;
using Backend.Application.Features.School.Students.Queries.GetById;
using Backend.Domain.Entities.Catalog;
using Backend.Domain.Entities.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Mappings.School
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<CreateStudentCommand, Student>().ReverseMap();
            CreateMap<GetStudentByIdResponse, Student>().ReverseMap();
            CreateMap<GetAllStudentsResponse, Student>().ReverseMap();
        }
    }
}
