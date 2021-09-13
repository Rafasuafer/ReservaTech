using Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Core
{
    public class Appointment
    {
        public virtual int Id { get; set; }
        public virtual int NumberOfCustomers { get; set; }
        public virtual DateTime Start { get; set; }
        public virtual DateTime End { get; set; }
        public virtual int RequestorId { get; set; }
        public virtual ApplicationUser Requestor { get; set; }
        public virtual string RequestorName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public virtual string RequestorEmail { get; set; }
        public virtual string RequestorPhone { get; set; }
        public virtual AppointmentStatus Status { get; set; }

        //TODO:
        //public virtual Unit Unit { get; set; }
        
    }
}
