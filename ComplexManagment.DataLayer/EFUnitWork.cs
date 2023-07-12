using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer
{
    public class EFUnitWork : UnitOfWork
    {
        private readonly EFDataContext _context;
        public EFUnitWork(EFDataContext context)
        {
            _context = context;
        }

        public void Complit()
        {
            _context.SaveChanges();
        }
    }
}
