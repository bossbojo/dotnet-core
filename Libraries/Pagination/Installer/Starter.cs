using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Libraries.Pagination.Installer
{
    public static class Starter
    {
        private static Context db = new Context();
        public static void go()
        {
            FileInfo file = new FileInfo("Libraries\\Pagination\\Installer\\EXEC_installer.sql");
            string script = file.OpenText().ReadToEnd();
            var check_have = db.installer.FromSql(script).FirstOrDefault();
            if (check_have.count_store == 0)
            {
                file = new FileInfo("Libraries\\Pagination\\Installer\\EXEC_s_Pagination.sql");
                script = file.OpenText().ReadToEnd();
                int create = db.Database.ExecuteSqlCommand(script);
                if (create == 0)
                {
                    throw new Exception("Filed for create store EXEC_s_Pagination.sql");
                }
            }
        }
    }
}