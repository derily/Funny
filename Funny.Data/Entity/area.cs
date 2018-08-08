using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funny.Data.Entity
{
    public  class area
    {
        public string id { get; set; }
        public string area_code { get; set; }
        public string area_name { get; set; }
        public string pinyin { get; set; }
        public string parent_code { get; set; }
        public char enabled { get; set; }
    }
}
