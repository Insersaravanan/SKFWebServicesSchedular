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
    public class EquipmentController : Controller
    {
        private readonly EquipmentRepo equipmentRepo;
        private IConfiguration _configuration;
        public EquipmentController(IConfiguration configuration)
        {
            equipmentRepo = new EquipmentRepo(configuration);
            _configuration = configuration;
           
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] EquipmentViewModel evm)
        {
            try
            {
                var result = await equipmentRepo.Update(evm);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new EmaintenanceMessage(ex.Message));
            }

        }
      
    }
}
