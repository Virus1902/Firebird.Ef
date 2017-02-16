using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdEf.DataAccess.Model;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Win32;

namespace FirebirdEf.DataAccess
{
    [DbConfigurationType(typeof(MyConfiguration))]
    public class FirebirdContext : DbContext
    {
        private static FbConnection GetConnection()
        {
            var connStrBuilder = new FbConnectionStringBuilder();
            connStrBuilder.DataSource = "localhost";
            connStrBuilder.Database = "localhost:C:\\db\\FirebirdEf.FDB";
            connStrBuilder.UserID = "sysdba";
            connStrBuilder.Password = "masterkey";
            connStrBuilder.Charset = "NONE";
            return new FbConnection(connStrBuilder.ToString());
        }

        public FirebirdContext() : base(GetConnection(), false)
        {
            Database.SetInitializer<FirebirdContext>(null);
        }

        public DbSet<Person> Persons { get; set; }
    }
}
