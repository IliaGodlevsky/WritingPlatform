﻿using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace WritingPlatform.Data
{
    internal class DataDbConfig : DbConfiguration
    {
        public DataDbConfig()
        {
            SetProviderServices("System.data.SqlClient", SqlProviderServices.Instance);
        }
    }
}
