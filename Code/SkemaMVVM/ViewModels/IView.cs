using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public interface IView
    {
        object DataContext { get; set; }
        void ViewModelClosingHandler(bool? dialogResult);
        void ViewModelActivatingHandler();
    }
}
