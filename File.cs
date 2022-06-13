using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class File
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Type { get; set; }
        //public string Link { get; set; }
    }
}
