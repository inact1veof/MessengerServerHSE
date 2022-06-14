using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class Book
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        //public int[] Members { get; set; }

        internal string _Members { get; set; }

        [NotMapped]
        public int[] Members
        {
            get { return _Members == null ? null : JsonConvert.DeserializeObject<int[]>(_Members); }
            set { _Members = JsonConvert.SerializeObject(value); }
        }
    }
}
