using Core.InterFaces.IAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models.Audit
{
    public class Audit : InterFaces.IAudit.IAudit
    {
        public DateTime CreatedDate { get ; set ; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
