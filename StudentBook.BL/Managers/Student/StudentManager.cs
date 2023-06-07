using AutoMapper;
using StudentBook.CoreLayer;
using StudentBook.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBook.BussinessLayer
{
    public class StudentManager : IStudentManager
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public StudentManager(IUnitOfWork _unitOfWork , IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task<int> Add(StudentAddDto studentDto)
        {
            var newStudent = mapper.Map<Student>(studentDto);
            await unitOfWork.StudentRepo.Add(newStudent);
            await unitOfWork.SaveChanges(); //====> returns the object added with its {Id} set by database provider
            return newStudent.Id;
        }

        public async Task Delete(int id)
        {
            var studentFromDB = await unitOfWork.StudentRepo.GetById(id);
            if (studentFromDB == null)
                return;
            unitOfWork.StudentRepo.Delete(studentFromDB);
            await unitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<StudentReadDto>> GetAll()
        {
            var studentsFromDB = await unitOfWork.StudentRepo.GetAll();
            return mapper.Map<List<StudentReadDto>>(studentsFromDB);
        }

        public async Task<StudentReadDto> GetById(int id)
        {
            var studentFromDB = await unitOfWork.StudentRepo.GetById(id);
            if (studentFromDB == null)
                return null;

            return mapper.Map<StudentReadDto>(studentFromDB);
        }

        public async Task<bool> Update(StudentUpdateDto studentDto)
        {
            var studentFromDB = await unitOfWork.StudentRepo.GetById(studentDto.Id);
            if (studentFromDB == null)
                return false;


            mapper.Map(studentDto, studentFromDB);

            unitOfWork.StudentRepo.Update(studentFromDB);

            await unitOfWork.SaveChanges();
            return true;
        }
        public bool StudentExists(int id)
        {
            return unitOfWork.StudentRepo.StudentExists(id);
        }
        public async Task<IEnumerable<StudentReadDto>> GetPaged(PaginationParameters PaginationParameters)
        {
            var studentsFromDB = await unitOfWork.StudentRepo.GetPaged(PaginationParameters);
            return mapper.Map<List<StudentReadDto>>(studentsFromDB);
        }
    }
}
