using AppApi.Entities.Table;
using System.Collections.Generic;
using System.Linq;
using AppApi.Models;
namespace AppApi.Repositories.Interfaces
{
    public interface ISimple
    {
        IEnumerable<SimpleTable> GetSimples();
        SimpleTable GetSimples(int id);
        SimpleTable CreateSimples(ModelSimple input);
        SimpleTable UpdateSimples(ModelSimple input,int id);
        bool DeleteSimples(int id);
    }
}