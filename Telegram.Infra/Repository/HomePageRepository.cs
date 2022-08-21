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
    public class HomePageRepository : IHomePageRepository
    {
        private readonly IDbContext DbContext;
        public HomePageRepository(IDbContext _DbContext)//dependency injection
        {
            DbContext = _DbContext;
        }

        public bool DeleteContactUs(ContactUs contactUs)
        {
            var p = new DynamicParameters();
            p.Add("@C_id ", contactUs.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("ContactUs_Package.DeleteContactUs", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<AboutUs> GetAboutUsInfo()
        {
            IEnumerable<AboutUs> result = DbContext.Connection.Query<AboutUs>("AboutUs_Package.GetAboutUsInfo", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<ContactUs> GetAllContactUs()
        {
            IEnumerable<ContactUs> result = DbContext.Connection.Query<ContactUs>("ContactUs_Package.GetAllContactUs", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Home> GetHomeInfo()
        {
            IEnumerable<Home> result = DbContext.Connection.Query<Home>("Home_Package.GetHomeInfo", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool InsertContactUs(ContactUs contactUs)
        {
            var p = new DynamicParameters();

            p.Add("@C_username", contactUs.username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@C_email", contactUs.email, dbType: DbType.String, direction: ParameterDirection.Input);

            p.Add("@C_subject", contactUs.subject, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@C_message", contactUs.message, dbType: DbType.String, direction: ParameterDirection.Input);

          
            var result = DbContext.Connection.ExecuteAsync("ContactUs_Package.InsertContactUs", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateAboutUsInfo(AboutUs aboutUs)
        {

            var p = new DynamicParameters();
            p.Add("@A_img", aboutUs.img, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@A_contant", aboutUs.contant, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("AboutUs_Package.UpdateAboutUsInfo", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateHomeInfo(Home home)
        {

            var p = new DynamicParameters();

            p.Add("@H_name", home.name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@H_logo", home.logo, dbType: DbType.String, direction: ParameterDirection.Input);

            p.Add("@H_Img", home.img, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@H_email", home.email, dbType: DbType.String, direction: ParameterDirection.Input);

            p.Add("@H_phone", home.phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@H_address", home.address, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync("Home_Package.UpdateHomeInfo", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
