using Messengers;

namespace ViewModels
{
    public interface IController
    {
        Messenger Messenger
        {
            get;
        }
    }
}
