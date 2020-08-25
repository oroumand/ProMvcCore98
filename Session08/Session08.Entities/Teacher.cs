﻿using System;
using System.Collections.Generic;

namespace Session08.Entities
{
    public class Teacher: IAuditable
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int InsertBy { get; set; }
        public int UpdateBy { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Dictionary<string, string> UpdateListproperties;
    }

  
}
