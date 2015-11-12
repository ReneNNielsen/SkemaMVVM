using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Teacher : Person
    {
        public List<int> ClassIds { get; set; }
        public List<int> SubjectIds { get; set; }
    }
}
