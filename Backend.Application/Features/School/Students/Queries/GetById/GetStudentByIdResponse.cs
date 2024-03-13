namespace Backend.Application.Features.School.Students.Queries.GetById
{
    public class GetStudentByIdResponse
    {
        public long Id { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}