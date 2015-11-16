using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using Services;

namespace Controllers
{
    public partial class TeacherController: BaseController, ITeacherController
    {
        private static TeacherContext TeacherContext;
        
        private TeacherController()
        {

        }

        public TeacherController(TeacherContext teacherContext)
        {
            TeacherContext = teacherContext;
        }
    }
}
