using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Core
{
    public class Unit : GenericEntity
    {
        public virtual  int Capacity { get; set; }
        public virtual  bool IsAvailable { get; set; }
        
        //TODO: Reservation
        //public virtual  List<Appointment> Appointments { get; set; }
    }
}
