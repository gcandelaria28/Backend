using Backend.Domain.Entities.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Seeds.School
{
    public class StudentSeeds
    {
        public static Student[] StudentList = new Student[]
        {
            new Student() {Id = 1, StudentId = 0001, Name = "Juan Dela Cruz", Address = "Batangas City"}
        };
    }
}
