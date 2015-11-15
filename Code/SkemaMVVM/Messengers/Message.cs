using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messengers
{
    public class Message
    {
        public Message(MessageTypes messageType)
        {
            this.messageType = messageType;
        }
        /// <summary>
        /// Has the message been handled
        /// </summary>
        public MessageHandledStatus HandledStatus
        {
            get;
            set;
        }
        /// <summary>
        /// What type of message is this
        /// </summary>
        private MessageTypes messageType;
        public MessageTypes MessageType
        {
            get
            {
                return messageType;
            }
        }
        /// <summary>
        /// The payload for the message
        /// </summary>
        public object Payload
        {
            get;
            set;
        }
    }
}
