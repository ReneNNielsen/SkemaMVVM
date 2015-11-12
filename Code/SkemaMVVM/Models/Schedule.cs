using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public int WeekNumber { get; set; }
        public int Year { get; set; }
        public Dictionary<string, List<int>> Subjects { get; set; }        
    }
}
