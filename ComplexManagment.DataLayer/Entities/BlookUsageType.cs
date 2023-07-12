using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Entities
{
    public class BlookUsageType
    {
        public int BlookId { get; set; }
        public Blook Blook { get; set; }
        public int UsageTypeId { get; set; }
        public UsageType UsageType { get; set; }
    }
}

