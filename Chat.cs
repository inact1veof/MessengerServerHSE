using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class Chat
    {
        public int Id { get; set; }
        public int[] Members { get; set; }
        public int[] Owners { get; set; }
        public string ChatName { get; set; }
        public string ChatImage { get; set; }
    }
}
