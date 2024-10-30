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
        Task<IEnumerable<Person>> FindAllAsync(CancellationToken cancellationToken = default);
        Task<Person?> FindByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(Person person, CancellationToken cancellationToken = default);
    }
}
