using System;
using System.Collections.Generic;
using FluentValidation.AspNetCore;
using System.Linq;
using System.Threading.Tasks;
using FluentValidationDI.Models;
using FluentValidationDI.Validation;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationDI.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        // POST api/values
        [HttpPost("add")]
        public bool Post([FromBody] PersonModel model)
        {
            var pv = new PersonValidator();
            var x = pv.Validate(model);
            return x.IsValid;
        }
    }
}
