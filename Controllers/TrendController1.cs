using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SKFWebServicesSchedular.Models;
using SKFWebServicesSchedular.Repository;
using SKFWebServicesSchedular.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKFWebServicesSchedular.Controllers
{
    public class TrendController : Controller
    {
        private readonly TrendRepo eventsRepo;

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] TrendViewModel tv)
        {

            try
            {
                var result = await eventsRepo.Update(tv);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new EmaintenanceMessage(ex.Message));
            }
        }


    }
}