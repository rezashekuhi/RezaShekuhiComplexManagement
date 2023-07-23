using ComplexManagment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement.Services.Unit.Test.Factory
{
    public static class UnitFactory
    {
        public static ComplexManagment.Entities.Unit Create(Blook block)
        {
            return new ComplexManagment.Entities.Unit
            {
                Name = "dummy",
                Resident = UnitType.mostager,
                Blook = block
            };
        }
    }
}
