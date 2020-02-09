﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniverseKino.WEB.Filters;

namespace UniverseKino.WEB
{
    [Route("customer")]
    [ApiController]
    [Authorize]
    [ServiceFilter(typeof(ExceptionFilter))]
    public class CustomerController : ControllerBase
    {
        [HttpPost("sessions/tobook")]
        public async  Task<IActionResult> ToBook([FromBody] ReservationRequestModel places)
        {
            return await Task.Run( () => Ok());
        }
    }
}
