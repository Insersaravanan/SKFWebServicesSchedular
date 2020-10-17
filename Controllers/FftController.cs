using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SKFWebServicesSchedular.Models;
using SKFWebServicesSchedular.Repository;
using System.Data;
using System.Data.SqlClient;
using SKFWebServicesSchedular.Utils;

namespace SKFWebServicesSchedular.Controllers
{
    public class FftController : Controller
    {
        private readonly FftRepo ffttRepo;
        private IConfiguration _configuration;
       

        public FftController(IConfiguration configuration)
        {
            ffttRepo = new FftRepo(configuration);
            _configuration = configuration;

        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] FftViewModel fvm)
        {
            try
            {
                var result = await ffttRepo.Update(fvm);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new EmaintenanceMessage(ex.Message));
            }

        }

    }
}
