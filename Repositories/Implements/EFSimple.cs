using System.Collections.Generic;
using AppApi.Configs;
using AppApi.Models.Table;
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