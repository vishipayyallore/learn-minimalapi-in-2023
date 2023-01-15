using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Entities
{
    
    public class Course : BaseEntity
    {
        public string? Title { get; set; }

        public int Credits { get; set; }
    }

}
