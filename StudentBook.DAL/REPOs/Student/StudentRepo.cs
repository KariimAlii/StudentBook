using Microsoft.EntityFrameworkCore;
using StudentBook.CoreLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBook.DataAccessLayer
{
    public class StudentRepo : GenericRepository<Student> , IStudentRepo
    {
        private readonly StudentBookContext context;

        public StudentRepo(StudentBookContext _context) : base(_context)
        {
            context = _context;
        }
        public bool StudentExists(int id)
        {
            return context.Student.Any(s => s.Id == id);
        }
        public async Task<IEnumerable<Student>> GetPaged(PaginationParameters PaginationParameters)
        {
            return await context.Set<Student>()
                .Skip((PaginationParameters.PageNumber - 1) * PaginationParameters.PageSize)
                .Take(PaginationParameters.PageSize)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
