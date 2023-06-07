using AutoMapper;
using StudentBook.CoreLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBook.BussinessLayer
{
    public class AutoMapperHandler : Profile
    {
        public AutoMapperHandler()
        {
            CreateMap<Student, StudentReadDto>();
            CreateMap<StudentAddDto, Student>();
            CreateMap<StudentUpdateDto, Student>();
            CreateMap<StudentReadDto, StudentUpdateDto>();
        }
    }
}
