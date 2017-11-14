using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidationDI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationDI.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private IValidator<PersonModel> _pv;

        public PersonController(IValidator<PersonModel> pv)
        {
            _pv = pv;
        }

        /*
            PASS THE FOLLOWING USING YOUR API
            http://localhost:54394/api/person/add

            INCLUDE THE JSON ON YOUR BODY                
            {
                "Id": 1,
                "Name": "Willi Vanilli",
                "Email": "willer@geocities.net",
                "Active": true
            }
        */

        // POST api/values
        [HttpPost("add")]
        public bool PostCommon([FromBody] PersonModel model)
        {
            var x = _pv.Validate(model, ruleSet: "common").IsValid;
            return x;
        }

        [HttpPost("addc")]
        public bool PostUnCommon([FromBody] PersonModel model)
        {
            var x = _pv.Validate(model, ruleSet: "uncommon").IsValid;
            return x;
        }
    }
}
