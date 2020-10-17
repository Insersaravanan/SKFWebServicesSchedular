using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SKFWebServicesSchedular.Models;
using SKFWebServicesSchedular.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Utility = SKFWebServicesSchedular.Services.Utility;

namespace SKFWebServicesSchedular.Repository
{
    public class TrendRepo
    {
        private readonly Utility util;

        public TrendRepo(IConfiguration configuration)
        {
            util = new Utility(configuration);
        }

        public async Task<IEnumerable<dynamic>> Update([FromBody] TrendViewModel evm)
        {
            string sql = "";
            using (var conn = util.MasterCon())
            {
                try
                {
                    return await (conn.QueryAsync<dynamic>(sql, new
                    {
                        evm.time,
                        evm.monitorId,
                        evm.jsonavg,
                        evm.jsonmin


                    }, commandType: CommandType.StoredProcedure));
                }
                catch (Exception ex)
                {
                    throw new CustomException("Unable to Save Or Update, Please Contact Support!!!", "Error", true, ex);
                }
            }
        }

    }
}

