using System;
using System.Collections.Generic;
using System.Text;

namespace Session08.EfDal
{
    public class UpdatePartialDTO
    {
        public int EtitiyId { get; set; }
        public Dictionary<string, string> Property {get;set;}
    }
}
