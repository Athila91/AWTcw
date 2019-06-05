using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Data.Common;
using System.Data;

namespace AWTcw.DatabaseConnection
{
    public  class Connection
    {
        public static Database Connect()
        {
            Database db = DatabaseFactory.CreateDatabase("connection");
            return db;

        }
    }
}