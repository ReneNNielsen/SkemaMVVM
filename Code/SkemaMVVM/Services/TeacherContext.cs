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

        public Teacher GetTeacher(int id)
        {
            return context.Teachers.Find(id);
        }

        public Teacher GetTeacher(string name)
        {
            List<Teacher> allTeachers = context.Teachers.ToList();
            foreach(Teacher teacher in allTeachers)
            {
                if (teacher.FirstName == name)
                    return teacher;
            }
            return null;
        }

        public List<Teacher> GetAllTeachers()
        {
            return context.Teachers.ToList();
        }
    }
}