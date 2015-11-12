using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messengers;
using ViewModels;

namespace Controllers
{
    public class BaseController : IController
    {
        public Messenger Messenger
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
