using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using rmz_meter_project.MeterDbcontext;
using rmz_meter_project.Models.DTO;
using rmz_meter_project.Repository;
using System.Web.Http.Description;

namespace rmz_meter_project.Controllers
{
    [ApiController]
    [Route("meter")]
    public class meterController : Controller
    {
        

        private readonly ImeterRepository meterRepository;

        public meterController(ImeterRepository meterRepository)
        {
            this.meterRepository = meterRepository;
        }

        [HttpPost]
        [Route("/GetAtLevel")]
        public IActionResult GetAtLevel([FromBody] RequestDTO request)
        {
            if (request.RequiredLevel != null)
            {
                if (request.RequiredLevel == "City")
                    return Ok(meterRepository.Citylevel(request.DateRange));
                else if (request.RequiredLevel == "Facility")
                    return Ok(meterRepository.Facilitylevel(request.DateRange));
                else if (request.RequiredLevel == "Building")
                    return Ok(meterRepository.Buildinglevel(request.DateRange));
                else if (request.RequiredLevel == "Floor")
                    return Ok(meterRepository.Floorlevel(request.DateRange));
                else if (request.RequiredLevel == "Zone")
                    return Ok(meterRepository.Zonelevel(request.DateRange));
                else if (request.RequiredLevel == "Meter")
                    return Ok(meterRepository.meterlevel(request.DateRange));
                else if (request.DateRange == null)
                {
                    return BadRequest("Date range is Required");
                }
                else
                    return BadRequest("Invalid Required Level");
            }
            
                return BadRequest("value is required");

        }
        
    }
}
