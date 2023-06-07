using StudentBook.CoreLayer;
using StudentBook.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBook.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentBookContext context;

        public IStudentRepo StudentRepo { get; }


        public UnitOfWork
        (
            IStudentRepo studentRepoFromIoc,
            StudentBookContext _context
        )
        {
            StudentRepo = studentRepoFromIoc;
            context = _context;
        }
        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }
    }
}
