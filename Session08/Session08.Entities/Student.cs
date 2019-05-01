using System;
using System.Collections.Generic;
using System.Text;

namespace Session08.Entities
{
    public class Student:IAuditable01
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentNumber { get; set; }

    }
}
