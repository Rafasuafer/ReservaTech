using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Core
{
    public class License
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual  Guid Key { get; set; }
        public virtual  DateTime Start { get; set; }
        public virtual  DateTime End { get; set; }
        public virtual  bool IsActive { get; set; }

    }
}
