using AppApi.Entities.Table;
using System.Collections.Generic;
using System.Linq;
namespace AppApi.Repositories.Interfaces
{
    public interface ISimple
    {
        IEnumerable<SimpleTable> GetSimples();
    }
}