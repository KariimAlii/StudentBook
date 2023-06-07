using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBook.BussinessLayer
{
    public class StudentReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? IsEnrolled { get; set; }
    }
}
