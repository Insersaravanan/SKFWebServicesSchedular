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
    public class EquipmentRepo
    {
        private readonly Utility util;

        public EquipmentRepo(IConfiguration configuration)
        {
            util = new Utility(configuration);
        }

        public async Task<IEnumerable<dynamic>> Update([FromBody] EquipmentViewModel evm)
        {
            string sql = "dbo.SEEquipmentHistory";
            using (var conn = util.MasterCon())
            {
                try
                {
                    return await (conn.QueryAsync<dynamic>(sql, new 
             
                {
                        evm.SEEquipmentHistoryId,
                        evm.startTime,
                        evm.endTime,
                        evm.macId,
                        evm.monitorId,
                        evm.state,
                        evm.timeDiff,
                        evm.clientSiteId
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
