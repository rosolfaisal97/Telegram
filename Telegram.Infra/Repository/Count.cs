using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Telegram.Core.Common;
using Telegram.Core.DTO;
using Telegram.Core.Repository;

namespace Telegram.Infra.Repository
{
    public class Count: ICount
    {
        private readonly IDbContext DbContext;
        public Count(IDbContext _DbContext)//dependency injection
        {
            DbContext = _DbContext;
        }

        public List<NumberOfChannels> NumberOfChannels()
        {
            IEnumerable<NumberOfChannels> result = DbContext.Connection.Query<NumberOfChannels>
                ("Counts_Package.NumberOfChannel", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<NumberOfGroups> NumberOfGroups()
        {
            IEnumerable<NumberOfGroups> result = DbContext.Connection.Query<NumberOfGroups>
                ("Counts_Package.NumberOfGroup", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<NumberOfUsers> NumberOfUsers()
        {

            IEnumerable<NumberOfUsers> result = DbContext.Connection.Query<NumberOfUsers>
                ("Counts_Package.NumberOfUser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
