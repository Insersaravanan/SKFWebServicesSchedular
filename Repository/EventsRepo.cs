using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SKFWebServicesSchedular.Models;
using SKFWebServicesSchedular.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SKFWebServicesSchedular.Repository
{
    public class EventsRepo
    {

        private readonly Utility util;

        public EventsRepo(IConfiguration configuration)
        {
            util = new Utility(configuration);
        }

        public async Task<IEnumerable<dynamic>> Update([FromBody] EventsViewModel evm)
        {
            string sql = "";
            using (var conn = util.MasterCon())
            {
                try
                {
                    return await (conn.QueryAsync<dynamic>(sql, new
                    {
                        evm.id,
                        evm.monitorId,
                        evm.time,
                        evm.level,
                        evm.featureName,
                        evm.value,
                        evm.threshold,
                        evm.status,
                        evm.description,
                        evm.featureCode,
                        evm.warningLimit,
                        evm.cautionLimit,
                        evm.count


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

