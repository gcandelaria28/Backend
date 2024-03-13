using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities.School
{
    public class Student
    {
        public new long Id { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
