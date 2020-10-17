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
    public class LoginController : Controller
    {
        private readonly LoginRepo loginRepo;
        [HttpPost]  
        public async Task<IActionResult> Save([FromBody] LoginViewModel lvm)
        {
            LoginViewModel login = new LoginViewModel();
            try
            {
                var result = await loginRepo.Update(lvm);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new EmaintenanceMessage(ex.Message));
            }
            
        }
    }
}
