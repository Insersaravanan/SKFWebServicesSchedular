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
    public class CompanyRepo
    {
        private readonly Utility util;
        public CompanyRepo(IConfiguration configuration)
        {
            util = new Utility(configuration);
        }

        public async Task<IEnumerable<dynamic>> SaveOrUpdate([FromBody] CompanyViewModel mvm)
        {
            string sql = "dbo.ENAppSaveCompany";
            mvm.languageId = 1;
            mvm.userId = 1;
            mvm.clientStatus = 6;
            mvm.id = 0;
            mvm.AppSource = "Enlight";

            try
            {
                using (var conn = util.MasterCon())
                {
                    return await (conn.QueryAsync<dynamic>(sql, new
                    {
                        mvm.id,
                        mvm.languageId,
                        mvm.name,
                        mvm.clientStatus,
                        mvm.userId,
                        mvm.clientId,
                        mvm.AppSource

                    }, commandType: CommandType.StoredProcedure));
                }
            }
            catch (Exception ex)
            {
                throw new CustomException("Unable to Save Or Update, Please Contact Support!!!", "Error", true, ex);
            }
        }


        public async Task<int> SaveOrUpdateSite([FromBody] SitesViewModel mvm)
        {
           // string sql = "dbo.ENAppSaveSites";

            try
            {
                string sql = @"Insert into dbo.TempClientSites(clientId,clientSiteId,nodeType,siteName,description,countryId,industryId,logo)
                           values(@clientId,@clientSiteId,@nodeType,@siteName,@description,@countryId,@industryId,@logo)";

                using (var conn = util.MasterCon())
                {
                    return await conn.ExecuteAsync(sql, new { mvm.clientId, mvm.clientSiteId, mvm.nodeType, mvm.siteName, mvm.description, mvm.countryId, mvm.industryId, mvm.logo});
                }
               
            }
            catch (Exception ex)
            {
                throw new CustomException("Unable to Save Or Update, Please Contact Support!!!", "Error", true, ex);
            }
        }
    }
}
