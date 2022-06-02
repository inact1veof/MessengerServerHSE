using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class Chat
    {
        public int Id { get; set; }
        public User[] Members { get; set; }
        public User[] Owners { get; set; }
        public string ChatImage { get; set; }
    }
}
