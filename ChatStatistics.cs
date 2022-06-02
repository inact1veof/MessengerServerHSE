using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class ChatStatistics
    {
        public int CountMessages { get; set; }
        public TimeSpan LifeTime { get; set; }
        public int CountFiles { get; set; }
        public int CountUsers { get; set; }
    }
}
