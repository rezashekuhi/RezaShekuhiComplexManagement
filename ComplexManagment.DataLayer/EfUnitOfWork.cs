using ComplexManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.Persistence.Ef
{
    public class EfUnitOfWork : UnitOfWork
    {
        private readonly EFDataContext _context;
        public EfUnitOfWork(EFDataContext context)
        {
            _context = context;
        }

        public void Complit()
        {
            _context.SaveChanges();
        }
    }
}
