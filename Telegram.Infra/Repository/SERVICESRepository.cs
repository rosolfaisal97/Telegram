using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Telegram.Core.Common;
using Telegram.Core.Data;
using Telegram.Core.Repository;

namespace Telegram.Infra.Repository
{
    public class SERVICESRepository : ISERVICESRepository
    {
        private readonly IDbContext DbContext;
        public SERVICESRepository(IDbContext _DbContext)//dependency injection
        {
            DbContext = _DbContext;
        }

        public bool CreateSERVICES(Services services)
        {
            var p = new DynamicParameters();
            p.Add("@SName", services.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@descript", services.descriptions, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@SPrice", services.Price, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@SImage", services.Image, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("SERVICES_Package.InsertSERVICES", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteSERVICES(int id)
        {
            var p = new DynamicParameters();
            p.Add("@S_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("SERVICES_Package.DeleteSERVICES", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Services> GetAllSERVICES()
        {
            IEnumerable<Services> result = DbContext.Connection.Query<Services>("SERVICES_Package.GetAllSERVICES", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateSERVICES(Services services)
        {
            var p = new DynamicParameters();
            p.Add("@S_id", services.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@SName", services.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@descript", services.descriptions, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@SPrice", services.Price, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@SImage", services.Image, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("SERVICES_Package.UpdateSERVICES", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
