using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBook.BussinessLayer
{
    public class StudentAddDto
    {
        public string Name { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Boolean IsEnrolled { get; set; } = false;
    }
}
