using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace WebApi
{
    [ModelBinder]
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int SenderUserId { get; set; }
        public int ReceiverChatId { get; set; }
        public DateTime sendTime { get; set; }
        public string[] Content { get; set; }
    }
}
