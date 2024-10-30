using PersonAdmin.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAdmin.Dal.Interface
{
    public interface IPersonDao
    {
        IEnumerable<Person> FindAll();
        Person? FindById(int id);
    }
}
