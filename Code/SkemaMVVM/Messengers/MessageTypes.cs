using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messengers
{
    public enum MessageTypes
    {
        MSG_Teacher_SELECTED_FOR_EDIT,// Sent when a Teacher is selected for editing
        MSG_Teacher_SAVED      // Sent when a Teacher is updated to the repository
    };
}
