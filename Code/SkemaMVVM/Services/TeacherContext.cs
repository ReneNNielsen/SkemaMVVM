using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public bool AddNewTeacher(Teacher newTeacher)
        {            
            Teacher insertedTeacher = context.Teachers.Add(newTeacher);
            context.SaveChanges();
            if (insertedTeacher.Id > 0)
            {
                return true;
            }
            return false;                        
        }

        public Teacher getTeacher(int id)
        {
            return context.Teachers.Find(id);
        }

        public DbSet<Teacher> getTeachers()
        {
            return context.Teachers;
        }
    }
}
