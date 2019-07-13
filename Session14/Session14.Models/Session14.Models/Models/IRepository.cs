using System.Collections.Generic;

namespace Session14.Models.Models
{
    public interface IRepository
    {
        IEnumerable<Person> People { get; }
        Person GetPerson(int id);
    }
}

