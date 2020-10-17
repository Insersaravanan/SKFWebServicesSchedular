using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SKFWebServicesSchedular.Models;
using SKFWebServicesSchedular.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SKFWebServicesSchedular.Repository
{
    public class MonitorsRepo
    {
        private readonly Utility util;
        public MonitorsRepo(IConfiguration configuration)
        {
            util = new Utility(configuration);
        }

        public Task<IEnumerable<dynamic>> SaveOrUpdate([FromBody] MonitorsViewModel mvm)
        {
            string sql = "dbo.EAppSaveMonitor";
            using (var conn = util.MasterCon())
            {
                return (conn.QueryAsync<dynamic>(sql, new
                    {
                        mvm.id,
                        mvm.monitorTypeName,
                        mvm.label,
                        mvm.isActive,
                        mvm.machineName,
                        mvm.deviceName,
                        mvm.machines,
                        mvm.devices,
                        mvm.monitorTypes,
                        mvm.orientation
                    }, commandType: CommandType.StoredProcedure));
            }
        }

        public async Task<int> SaveOrUpdatefft([FromBody] FftViewModel mvm)
        {
            // string sql = "dbo.ENAppSaveSites";

            try
            {
                string sql = @"Insert into dbo.Tempfft(id, time)
                           values(@id,@time)";

                using (var conn = util.MasterCon())
                {
                    return await conn.ExecuteAsync(sql, new { mvm.id, mvm.time,});
                }

            }
            catch (Exception ex)
            {
                throw new CustomException("Unable to Save Or Update, Please Contact Support!!!", "Error", true, ex);
            }
        }
    }
}
