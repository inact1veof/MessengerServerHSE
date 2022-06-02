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
        public User Sender { get; set; }
        public Chat Receiver { get; set; }
        public string[] Content { get; set; }
    }
}
