using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using Views;

namespace Controllers
{
    public partial class TeacherController : ITeacherController
    {
        private void ShoewViewTeacherSelection()
        {
            SelectTeacherView v = new SelectTeacherView();
        }

        private void GetTeacherSelectionView(BaseViewModel parrent = null)
        {
            SelectTeacherView v = new SelectTeacherView();
            
        }
    }
}
