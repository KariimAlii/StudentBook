using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBook.DataAccessLayer
{
    public interface IUnitOfWork
    {
        public IStudentRepo StudentRepo { get; }
        Task<int> SaveChanges();
    }
}
