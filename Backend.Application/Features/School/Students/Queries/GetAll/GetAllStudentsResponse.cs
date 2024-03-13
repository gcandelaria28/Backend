namespace Backend.Application.Features.School.Students.Queries.GetAll
{
    public class GetAllStudentsResponse
    {
        public long Id { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}