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
    public class FftRepo
    {
        private readonly Utility util;

        public FftRepo(IConfiguration configuration)
        {
            util = new Utility(configuration);
        }

        public async Task<IEnumerable<dynamic>>Update([FromBody] FftViewModel fvm)
        {
            string sql = "";
            using (var conn = util.MasterCon())
            {
                try
                {
                    return await (conn.QueryAsync<dynamic>(sql, new

                    {
                        //fvm.SEFftHistoryId,
                        //fvm.startTime,
                        //fvm.endTime,
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
