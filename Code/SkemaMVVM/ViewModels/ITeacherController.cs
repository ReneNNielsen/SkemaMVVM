using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public interface ITeacherController : IController
    {
        /// <summary>
        /// Do whatever needs to be done when a Customer is selected (i.e. edit it)
        /// </summary>
        /// <param name="customerId"></param>
        void TeacherSelectedForEdit(TeacherListItemViewData data, BaseViewModel daddy);
        /// <summary>
        /// Edit this customer Id
        /// </summary>
        /// <param name="customerId"></param>
        void Edit(int customerId, BaseViewModel daddy);
        /// <summary>
        /// Update Customer data in the repository
        /// </summary>
        /// <param name="data"></param>
        void UpdateTeacher(TeacherEditViewData data);
    }
}
