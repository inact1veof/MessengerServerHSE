using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class AdminStatistics
    {
        public int id { get; set; }
        public int CountUsers { get; set; }
        public int CountChats { get; set; }
        public int AverageNumberMessages { get; set; }
        public int AverageNumberChatUsers { get; set; }
        public int Frequency { get; set; }
    }
}
