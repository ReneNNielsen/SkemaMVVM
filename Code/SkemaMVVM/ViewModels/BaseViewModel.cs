using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    /// <summary>
    /// When the VM is closed, the associated V needs to close too
    /// </summary>
    /// <param name="sender"></param>
    public delegate void ViewModelClosingEventHandler(bool? dialogResult);

    /// <summary>
    /// When a pre-existing VM is activated the View needs to activate itself
    /// </summary>
    public delegate void ViewModelActivatingEventHandler();

    public class BaseViewModel : ObservableObject
    {
        public event ViewModelClosingEventHandler ViewModelClosing;
        public event ViewModelActivatingEventHandler ViewModelActivating;

        /// <summary>
        /// Keep a list of any children ViewModels so we can safely remove them when this ViewModel gets closed
        /// </summary>
        private List<BaseViewModel> childViewModels = new List<BaseViewModel>();
        public List<BaseViewModel> ChildViewModels
        {
            get { return childViewModels; }
        }

        private BaseViewData viewData;
        public BaseViewData ViewData
        {
            get
            {
                return viewData;
            }
            set
            {
                if (value != viewData)
                {
                    viewData = value;
                    base.NotifyPropertyChanged("ViewData");
                }

            }
        }

        /// <summary>
        /// If the ViewModel wants to do anything, it needs a controller
        /// </summary>
        protected IController Controller
        {
            get;
            set;
        }

        public BaseViewModel()
        {

        }

        public BaseViewModel(IController controller)
        {
            Controller = controller;
        }

        /// <summary>
        /// Create the View Model with a Controller and a FrameworkElement (View) injected.
        /// Note that we don't keep a reference to the View - just set its data context and
        /// subscribe it to our Activating and Closing events...
        /// Of course, this means there are references - that must be removed when the view closes,
        /// which is handled in the BaseView
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="view"></param>
        //public BaseViewModel(IController controller, FrameworkElement view)
        public BaseViewModel(IController controller, IView view)
            : this(controller)
        {
            if (view != null)
            {
                view.DataContext = this;
                ViewModelClosing += view.ViewModelClosingHandler;
                ViewModelActivating += view.ViewModelActivatingHandler;
            }
        }

        /// <summary>
        /// De-Register the VM from the Messenger to avoid non-garbage collected VMs receiving messages
        /// Tell the View (via the ViewModelClosing event) that we're closing.
        /// </summary>
        public void CloseViewModel(bool? dialogResult)
        {
            Controller.Messenger.DeRegister(this);
            if (ViewModelClosing != null)
            {
                ViewModelClosing(dialogResult);
            }
            foreach (var childViewModel in childViewModels)
            {
                childViewModel.CloseViewModel(dialogResult);
            }
        }

        public void ActivateViewModel()
        {
            if (ViewModelActivating != null)
            {
                ViewModelActivating();
            }
        }
    }
}
