using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messengers;
using System.Windows.Input;
using System.Windows.Threading;

namespace ViewModels
{
    public class TeacherSelectViewModel : PersonSelectViewModel
    {
        private ITeacherController TeacherController
        {
            get
            {
                return (ITeacherController)Controller;
            }
        }

        /// <summary>
        /// Required to allow our DesignTime version to be instantiated
        /// </summary>
        protected TeacherSelectViewModel()
        {
        }

        public TeacherSelectViewModel(ITeacherController controller)
            : this(controller, null)
        {

        }

        /// <summary>
        /// Use the base class to store the controller and set the Data Context of the view (view)
        /// Initialise any data that needs initialising
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="view"></param>
        public TeacherSelectViewModel(ITeacherController controller, IView view)
            : base(controller, view)
        {
            controller.Messenger.Register(MessageTypes.MSG_Teacher_SAVED, new Action<Message>(RefreshList));
        }


        private void RefreshList(Message message)
        {
            RefreshList();
            message.HandledStatus = MessageHandledStatus.HandledContinue;
        }

        /// <summary>
        /// Ask for an updated list of customers based on the filter
        /// </summary>
        private void RefreshList()
        {
            ViewData = TeacherController.GetTeacherSelectionViewData(StateFilter);
        }

    }
}
