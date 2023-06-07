using StudentBook.CoreLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBook.BussinessLayer
{
    public interface IStudentManager
    {
        Task<IEnumerable<StudentReadDto>> GetAll();
        Task<StudentReadDto> GetById(int id);
        Task<int> Add(StudentAddDto studentDto);
        Task<bool> Update(StudentUpdateDto studentDto);
        Task Delete(int id);
        bool StudentExists(int id);
        Task<IEnumerable<StudentReadDto>> GetPaged(PaginationParameters PaginationParameters);
    }
}
