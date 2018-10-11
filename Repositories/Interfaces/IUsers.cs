using System;
using System.Collections.Generic;
using AppApi.Entities.Table;
using AppApi.Models;

namespace AppApi.Repositories.Interfaces
{
    public interface IUsers
    {
        IEnumerable<Users> GetUsers();
        Users GetUsers(int id);
        Users CreateUsers(ModelUsers input);
        Users UpdateUsers(ModelUsers input, int id);
        bool DeleteUsers(int id);
    }
}