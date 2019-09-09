using System.Collections.Generic;
using Myob.Fma.BookingLibrary.Core;

namespace Myob.Fma.BookingLibrary.Memberships
{
    public interface IMembership
    {
        void Add(Person person);
        void Remove(int id);
        void Update(Person person);
        void Delete(int id);
        Person Get(int id);
        List<Person> GetAll();
    }
}