using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocContractValidation.Provider.Models;
using PocContractValidation.Provider.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PocContractValidation.Provider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderLockedController : ControllerBase
    {
        // GET: api/<OrderLockedController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<OrderLockedController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<OrderLockedEvent> SendOrderLocked()
        {
            // We create an order locked event
            var realisticPayloadService = new RealisticPayloadService();
            var orderLockedEvent = realisticPayloadService.BuildOrderLockedEvent();

            // ... send the event to a topic

            return orderLockedEvent;
        }
    }
}
