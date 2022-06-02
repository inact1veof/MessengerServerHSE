using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class Book
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int[] Members { get; set; }
    }
}
