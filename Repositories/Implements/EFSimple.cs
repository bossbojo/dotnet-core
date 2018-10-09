using System.Collections.Generic;
using AppApi.Entities;
using AppApi.Entities.Table;
using AppApi.Repositories.Interfaces;
using System.Linq;

namespace AppApi.Repositories.Implements
{
    public class EFSimple : ISimple
    {
        private ConnectDB db = new ConnectDB();
        public IEnumerable<SimpleTable> GetSimples()
        {
            return db.SimpleTable.ToList();
        }
    }
}