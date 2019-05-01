using System.Collections.Generic;

namespace Session08.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Contact> Contact { get; set; }
        public JobData JobData { get; set; }


    }

    public class Contact
    {
        public int ContactId { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
    public class JobData
    {
        public int JobDataId { get; set; }
        public string JobTitle { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
