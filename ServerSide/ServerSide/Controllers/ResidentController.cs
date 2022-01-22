using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("EntireCore")] // Enable CORS specific policy

    public class ResidentController : ControllerBase
    {
        private readonly ResidentsLogic residentsLogic;
        public ResidentController(ResidentsLogic logic)
        {
            this.residentsLogic = logic;
        }

        [HttpGet]
        public IActionResult GetAllResidents()
        {
            try
            {
                IEnumerable<ResidentsModel> residents = residentsLogic.GetAllResidents();
                return Ok(residents);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetAllResidentsByCity")]
        public IActionResult GetAllResidentsByCity(string cityName)
        {
            try
            {
                IEnumerable<ResidentsModel> residentsByName = residentsLogic.GetAllResidentsByName(cityName);
                return Ok(residentsByName);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
