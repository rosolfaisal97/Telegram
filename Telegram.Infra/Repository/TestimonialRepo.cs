﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Telegram.Core.Common;
using Telegram.Core.Data;
using Telegram.Core.DTO;
using Telegram.Core.Repository;
using Telegram.Core.Service;

namespace Telegram.Infra.Repository
{
    public class TestimonialRepo : ITestimonial
    {
        public readonly IDbContext DbContext;

        public TestimonialRepo(IDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public bool DeleteTestimonial(int T_id)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@T_id", T_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync
                ("Testimonial_Package.DeleteTestimonial", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }
        public List<GetSingleTestimonial> GetSingleTestimonial(int T_id)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@T_id", T_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<GetSingleTestimonial> result = DbContext.Connection.Query<GetSingleTestimonial>
                 ("Testimonial_Package.GetSingleTestimonial", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public List<GetAllTestimonial> GetAllTestimonial()
        {
            IEnumerable<GetAllTestimonial> result = DbContext.Connection.Query<GetAllTestimonial>
               ("Testimonial_Package.GetAllTestimonial", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<GetAcceptTestimonialDto> GetAcceptTestimonial()
        {
            IEnumerable<GetAcceptTestimonialDto> result = DbContext.Connection.Query<GetAcceptTestimonialDto>
               ("Testimonial_Package.GetAcceptTestimonial", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public Testimonial InsertTestimonial(Testimonial Test)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("Fuser", Test.user_from, dbType: DbType.Int32, direction: ParameterDirection.Input);

            parameter.Add
                ("descript", Test.description, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("accepting", Test.is_accept, dbType: DbType.Int32, direction: ParameterDirection.Input);
            

            var result = DbContext.Connection.ExecuteAsync
                ("Testimonial_Package.InsertTestimonial", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return Test;
        }

        public bool UpdateTestimonial(Testimonial Test)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("T_id", Test.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("Fuser", Test.user_from, dbType: DbType.Int32, direction: ParameterDirection.Input);
            
            parameter.Add
                ("descript", Test.description, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("accepting", Test.is_accept, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync
                ("Testimonial_Package.UpdateTestimonial", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;
        }
    }
}