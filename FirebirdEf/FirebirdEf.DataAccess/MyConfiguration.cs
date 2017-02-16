using System.Data.Entity;
using FirebirdSql.Data.EntityFramework6;
using FirebirdSql.Data.FirebirdClient;
using FbProviderServices = FirebirdSql.Data.EntityFramework6.FbProviderServices;

namespace FirebirdEf.DataAccess
{
    public class MyConfiguration : DbConfiguration
    {
        public MyConfiguration()
        {
            SetProviderServices("FirebirdSql.Data.FirebirdClient", FbProviderServices.Instance);
            SetProviderFactory("FirebirdSql.Data.FirebirdClient", FirebirdClientFactory.Instance);
            SetDefaultConnectionFactory(new FbConnectionFactory());
        }
    }
}
