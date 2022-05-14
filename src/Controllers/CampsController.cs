using CoreCodeCamp.Data;
using CoreCodeCamp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCodeCamp.Controllers
{
    [Route("api/[Controller]")]
    public class CampsController : ControllerBase
    {
        private readonly ICampRepository _campRepository;

        public CampsController(ICampRepository campRepository)
        {
            _campRepository = campRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCamps()
        {
            try
            {
                var result = await _campRepository.GetAllCampsAsync();
                //CampModel[] = ;
                return Ok(result);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
