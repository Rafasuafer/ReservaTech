using System;
using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Entities.Core
{
    public class Appointment : GenericEntity
    {
        public virtual int NumberOfCustomers { get; set; }
        public virtual DateTime Start { get; set; }
        public virtual DateTime End { get; set; }
        public virtual int RequesterId { get; set; }
        public virtual ApplicationUser Requester { get; set; }
        public virtual string RequesterName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public virtual string RequesterEmail { get; set; }
        public virtual string RequesterPhone { get; set; }
        public virtual AppointmentStatus Status { get; set; }

        //TODO:
        //public virtual Unit Unit { get; set; }
        
    }
}
