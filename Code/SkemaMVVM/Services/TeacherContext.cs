using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TeacherContext : DataContext
    {
        DataContext context;

        public TeacherContext()
        {
            context = new DataContext();
        }

        public DataContext DataContext
        {
            get { return context; }
        }

        public bool AddNewTeacher(string name)
        {
            Teacher newTeacher = new Teacher()
            {
                FirstName = name
            };

            context.Teachers.Add(newTeacher);

            return true;
        }
    }
}
