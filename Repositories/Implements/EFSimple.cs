using System.Collections.Generic;
using AppApi.Entities;
using AppApi.Entities.Table;
using AppApi.Repositories.Interfaces;
using System.Linq;
using AppApi.Models;

namespace AppApi.Repositories.Implements
{
    public class EFSimple : ISimple
    {
        private ConnectDB db = new ConnectDB();
        
        //Get all Simple
        public IEnumerable<SimpleTable> GetSimples()
        {
            return db.SimpleTable.ToList();
        }
        //Get By Id Simple
        public SimpleTable GetSimples(int id)
        {
            return db.SimpleTable.FirstOrDefault(c => c.Id == id);
        }
        public SimpleTable CreateSimples(ModelSimple input)
        {
            var create = db.SimpleTable.Add(new SimpleTable
            {
                Firstname = input.firstname,
                Lastname = input.lastname
            });
            int save = db.SaveChanges();
            if (save > 0)
            {
                return create.Entity;
            }
            throw new System.Exception("Save to database is failed");
        }

        public bool DeleteSimples(int id)
        {
            var delete = db.SimpleTable.FirstOrDefault(c => c.Id == id);
            db.Remove(delete);
            int save = db.SaveChanges();
            if (save > 0)
            {
                return true;
            }
            throw new System.Exception($"Delete failed for Id = {id}");
        }

        public SimpleTable UpdateSimples(ModelSimple input, int id)
        {
            var update = db.SimpleTable.FirstOrDefault(c => c.Id == id);
            update.Firstname = input.firstname;
            update.Lastname = input.lastname;
            int save = db.SaveChanges();
            if (save > 0)
            {
                return update;
            }
            throw new System.Exception("Save to database is failed");
        }
    }
}