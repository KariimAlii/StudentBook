using StudentBook.CoreLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBook.DataAccessLayer
{
    public interface IStudentRepo : IGenericRepository<Student>
    {
        Task<IEnumerable<Student>> GetPaged(PaginationParameters PaginationParameters);
        bool StudentExists(int id);
    }
}
