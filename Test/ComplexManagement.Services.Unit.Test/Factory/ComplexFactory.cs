using ComplexManagment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement.Services.Unit.Test.Factory
{
    public static class ComplexFactory
    {
        public static Complex Create()
        {
            return new Complex
            {
                Name = "dummy",
                UnitCount = 50
            };
        }
    }
}
