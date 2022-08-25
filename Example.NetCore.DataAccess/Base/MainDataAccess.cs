using Example.NetCore.DataAccess.Contracts;
using Example.NetCore.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.NetCore.DataAccess.Base
{
    public class MainDataAccess
    {
        internal readonly ConnectionStrings _connectionStrings;
        internal readonly IDataAccess _dataAccess;

        public MainDataAccess(AppSettings appSettings, IDataAccess dataAccess)
        {
            if (appSettings == null)
            {
                throw new ArgumentNullException(nameof(appSettings), "Configuration not received");
            }
            if (dataAccess == null)
            {
                throw new ArgumentNullException(nameof(dataAccess), "Data access not received");
            }

            _connectionStrings = appSettings.ConnectionStrings;
            _dataAccess = dataAccess;
        }
    }
}
