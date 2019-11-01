﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningSampleApp.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/Values")]
    public class ValuesV1Controller : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Value1 from Version 1", "value2 from Version 1" };
        }
    }

    [ApiVersion("2.0")]
    [Route("api/Values")]
    public class ValuesV2Controller : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1 from Version 2", "value2 from Version 2" };
        }
    }
}
