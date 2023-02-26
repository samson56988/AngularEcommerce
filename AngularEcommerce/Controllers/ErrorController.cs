﻿using AngularEcommerce.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularEcommerce.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    public class ErrorController : BaseApiController
    {
        [HttpGet("errors")]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
