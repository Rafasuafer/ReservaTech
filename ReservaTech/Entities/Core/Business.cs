using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enums;

namespace Entities.Core
{
    public class Business : GenericEntity
    {
        public virtual string Name { get; set; }
        public virtual BusinessType Type { get; set; }
        public virtual List<Unit> Units { get; set; }
        public virtual List<ApplicationUser> Clients { get; set; }
        public virtual License License { get; set; }
        public virtual List<DailySchedule> Schedule { get; set; }
        public virtual BusinessRules Rules { get; set; }

    }
}
