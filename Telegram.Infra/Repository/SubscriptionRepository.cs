using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Telegram.Core.Common;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;

namespace Telegram.Infra.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {


        private readonly IDbContext DbContext;
        public SubscriptionRepository(IDbContext _DbContext)//dependency injection
        {
            DbContext = _DbContext;
        }

        public bool DeleteSubscription(Subscription subscription)
        {
            var p = new DynamicParameters();
            p.Add("@Sub_id", subscription.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("Subscription_Package.DeleteSubscription", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<GetAllSubscription> GetAllSubscription()
        {
            IEnumerable<GetAllSubscription> result = DbContext.Connection.Query<GetAllSubscription>("Subscription_Package.GetAllSubscription", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<ProfitsAndLosses> GetProfitsAndLosses()
        {
            IEnumerable<ProfitsAndLosses> result = DbContext.Connection.Query<ProfitsAndLosses>("ProfitsAndLosses", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<GetUserSubscription> GetUserSubscription(int Uid)
        {
            var p = new DynamicParameters();
            p.Add("@U_id", Uid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<GetUserSubscription> result = DbContext.Connection.Query<GetUserSubscription>("Subscription_Package.GetUserSubscription", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool InsertSubscription(Subscription subscription)
        {
            var p = new DynamicParameters();
            p.Add("@S_Id", subscription.servicesId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@U_Id", subscription.userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            

            var result = DbContext.Connection.ExecuteAsync("Subscription_Package.InsertSubscription", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
