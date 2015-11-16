using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Models;
using System.Collections.Generic;

namespace DbTests
{
    [TestClass]
    public class DbTests
    {

        [TestMethod]
        public void AddNewTeacherToDb()
        {
            bool success = false;
            Teacher newTeacher = new Teacher()
            {
                FirstName = "Fornavn",
                LastName = "Efternavn",
                SocialSecurityNumber = 010170,
                Address = "Hallovej 123",
                ZipCode = 1234,
                City = "Randers ikke"
            };
            using (var tc = new TeacherContext())
            {
                success = tc.AddNewTeacher(newTeacher);
            }
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void getTeacherFromDb()
        {
            int id = 1;
            Teacher searchedTeacher;
            using (var tc = new TeacherContext())
            {
                searchedTeacher = tc.GetTeacher(id);
            }
            Assert.IsNotNull(searchedTeacher.Id);
        }


        [TestMethod]
        public void getTeacherFromDbByName()
        {
            string name = "Fornavn";
            Teacher searchedTeacher;
            using (var tc = new TeacherContext())
            {
                searchedTeacher = tc.GetTeacher(name);
            }
            Assert.IsNotNull(searchedTeacher);
        }

        [TestMethod]
        public void getTeachersFromDb()
        {
            List<Teacher> allTeachers;
            using (var tc = new TeacherContext())
            {
                allTeachers = tc.GetAllTeachers();
            }
            Assert.IsNotNull(allTeachers);
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            using (var tc = new TeacherContext())
            {
                if(tc.Database.Exists())
                {
                    //tc.Database.Delete();
                }
            }
        }
    }
}
