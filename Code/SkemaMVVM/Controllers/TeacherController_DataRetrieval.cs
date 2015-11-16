using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Controllers
{
    public partial class TeacherController
    {
        public TeacherSelectViewData GetTeacherSelectionViewData()
        {
            TeacherSelectViewData viewData = new TeacherSelectViewData();
            viewData.Persons = new System.Collections.ObjectModel.ObservableCollection<PersonListItemViewData>();

            foreach (var teacher in TeacherContext.GetTeachers())
            {
                viewData.Persons.Add(new TeacherListItemViewData()
                {
                    Id = teacher.Id,
                    Name = teacher.Name
                });
            }
            return viewData;
        }
    }
}
