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
    public class EventsController : Controller
    {
        private readonly EventsRepo eventsRepo;

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] EventsViewModel ev)
        {
           
            try
            {
                var result = await eventsRepo.Update(ev);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new EmaintenanceMessage(ex.Message));
            }
        }

      
    }
}
