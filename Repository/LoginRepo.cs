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
    public class LoginRepo
    {

        private readonly Utility util;

        public LoginRepo(IConfiguration configuration)
        {
            util = new Utility(configuration);
        }

        public async Task<IEnumerable<dynamic>> Update([FromBody] LoginViewModel lvm)
        {
            string sql = "";
            using (var conn = util.MasterCon())
            {
                try
                {
                    return await (conn.QueryAsync<dynamic>(sql, new
                    {
                        lvm.id,
                        lvm.userName,
                        lvm.firstName,
                        lvm.lastName,
                        lvm.email,
                        lvm.phoneNumber,
                        lvm.language,
                        lvm.accessToken,
                        lvm.loggedIn,
                        lvm.admin
                        

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
