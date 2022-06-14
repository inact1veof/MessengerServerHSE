using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class Chat
    {
        public int Id { get; set; }
        //public int[] Members { get; set; }
        //public int[] Owners { get; set; }
        public string ChatName { get; set; }
        public string ChatImage { get; set; }
        public DateTime CreationDate { get; set; }

        internal string _Members { get; set; }
        internal string _Owners { get; set; }

        [NotMapped]
        public int[] Members
        {
            get { return _Members == null ? null : JsonConvert.DeserializeObject<int[]>(_Members); }
            set { _Members = JsonConvert.SerializeObject(value); }
        }
        [NotMapped]
        public int[] Owners
        {
            get { return _Owners == null ? null : JsonConvert.DeserializeObject<int[]>(_Owners); }
            set { _Owners = JsonConvert.SerializeObject(value); }
        }
    }
}
