using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ViewModels;

namespace Views
{
    /// <summary>
    /// A delegate to allow the window closed event to be handled (if required)
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    public delegate void OnWindowClose(Object sender, EventArgs e);

    public partial class BaseView : UserControl, IDisposable, IView
    {
        private ViewWindow viewWindow; // If shown on a window, the window in question
        private OnWindowClose onWindowClosed = null;

        public BaseView()
        {
        }

        /// <summary>
		/// The view is closing, so clean up references
		/// </summary>
		public void ViewClosed()
        {
            // In order to handle the case where the user closes the window (rather than us controlling the close via a ViewModel)
            // we need to check that the DataContext isn't null (which would mean this ViewClosed has already been done)
            if (DataContext != null)
            {
                ((BaseViewModel)DataContext).ViewModelClosing -= ViewModelClosingHandler;
                ((BaseViewModel)DataContext).ViewModelActivating -= ViewModelActivatingHandler;
                this.DataContext = null; // Make sure we don't have a reference to the VM any more.
            }
        }

        /// <summary>
		/// Handle the Window Closed event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ViewsWindow_Closed(object sender, EventArgs e)
        {

            if (onWindowClosed != null)
            {
                onWindowClosed(sender, e);
            }
            ((BaseViewModel)DataContext).CloseViewModel(false);
        }

        #region Showing methods
        /// <summary>
        /// Show this control in a window, sized to fit, with this title
        /// </summary>
        /// <param name="windowTitle"></param>
        public void ShowInWindow(bool modal, string windowTitle)
        {
            ShowInWindow(modal, windowTitle, 0, 0, Dock.Top, null);
        }

        /// <summary>
        /// Show this control in an existing window, by default docked top.
        /// </summary>
        /// <param name="window"></param>
        public void ShowInWindow(bool modal, ViewWindow window)
        {
            ShowInWindow(modal, window, window.Title, window.Width, window.Height, Dock.Top, null);
        }

        /// <summary>
        /// Maximum Flexibility of Window Definition version of Show In Window
        /// </summary>
        /// <param name="window">THe Window in which to show this View</param>
        /// <param name="windowTitle">A Title for the Window</param>
        /// <param name="windowWidth">The Width of the Window</param>
        /// <param name="windowHeight">The Height of the Window</param>
        /// <param name="dock">How should the View be Docked</param>
        /// <param name="onWindowClosed">Event handler for when the window is closed</param>
        public void ShowInWindow(bool modal, ViewWindow window, string windowTitle, double windowWidth, double windowHeight, Dock dock, OnWindowClose onWindowClose)
        {
            this.onWindowClosed = onWindowClose;

            viewWindow = window;
            viewWindow.Title = windowTitle;

            DockPanel.SetDock(this, dock);
            // The viewWindow must have a dockPanel called WindowDockPanel. If you want to change this to use some other container on the window, then
            // the below code should be the only place it needs to be changed.
            viewWindow.WindowDockPanel.Children.Add(this);

            if (windowWidth == 0 && windowHeight == 0)
            {
                viewWindow.SizeToContent = SizeToContent.WidthAndHeight;
            }
            else
            {
                viewWindow.SizeToContent = SizeToContent.Manual;
                viewWindow.Width = windowWidth;
                viewWindow.Height = windowHeight;
            }

            if (modal)
            {
                viewWindow.ShowDialog();
            }
            else
            {
                viewWindow.Show();
            }
        }

        /// <summary>
        /// Show the View in a New Window
        /// </summary>
        /// <param name="windowTitle">Give the Window a Title</param>
        /// <param name="windowWidth">Set the Window's Width</param>
        /// <param name="windowHeight">Set the Window's Height</param>
        /// <param name="dock">How to Dock the View in the Window</param>
        /// <param name="onWindowClosed">Event handler for when the Window closes</param>
        public void ShowInWindow(bool modal, string windowTitle, double windowWidth, double windowHeight, Dock dock, OnWindowClose onWindowClose)
        {
            ShowInWindow(modal, ViewWindow, windowTitle, windowWidth, windowHeight, dock, onWindowClose);
        }
        #endregion
        #region IDisposable Members

        void IDisposable.Dispose()
        {
            // Remove any events from our window to prevent any memory leakage.
            if (viewWindow != null)
            {
                viewWindow.Closed -= this.ViewsWindow_Closed;
            }
        }

        #endregion

        #region IView implementations
        /// <summary>
        /// Tell the View to close itself. Handle the case where we're in a window and the window needs closing.
        /// </summary>
        /// <param name="dialogResult"></param>
        public void ViewModelClosingHandler(bool? dialogResult)
        {
            if (viewWindow == null)
            {
                System.Windows.Controls.Panel panel = this.Parent as System.Windows.Controls.Panel;
                if (panel != null)
                {
                    panel.Children.Remove(this);
                }
            }
            else
            {
                viewWindow.Closed -= ViewsWindow_Closed;

                if (viewWindow.IsDialogWindow)
                {
                    // If the window is a Dialog and is not actiuve it must be in the process of being closed
                    if (viewWindow.IsActive)
                    {
                        viewWindow.DialogResult = dialogResult;
                    }
                }
                else
                {
                    viewWindow.Close();
                }
                viewWindow = null;
            }
            // Process the ViewClosed method to cater for if this has been instigated by the user closing a window, rather than by
            // the close being instigated by a ViewModel
            ViewClosed();
        }

        public void ViewModelActivatingHandler()
        {
            if (viewWindow != null)
            {
                viewWindow.Activate();
            }
        }
        #endregion

    }
}
