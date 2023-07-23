using ComplexManagment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement.Services.Unit.Test.Factory
{
    public static class BlockFactory
    {
        public static Blook Create(Complex complex)
        {
            return new Blook
            {
                Name = "dummy",
                UnitCount =10,
                Complex = complex
                 
            };
        }
    }
}
