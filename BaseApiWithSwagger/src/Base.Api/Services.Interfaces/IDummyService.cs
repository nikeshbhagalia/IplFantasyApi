using Base.Api.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.Api.Services.Interfaces
{
    public interface IDummyService
    {
        IEnumerable<Dummy> Get();

        Dummy Get(string id);

        Task Create(Dummy dummy);

        Task Update(string id, Dummy updateDummy);

        Task Delete(string id);
    }
}
