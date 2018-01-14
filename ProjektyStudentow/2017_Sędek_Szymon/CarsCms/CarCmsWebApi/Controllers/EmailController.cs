using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using CarCmsWebApi.Models;
using CarCmsWebApi.Service;

namespace CarCmsWebApi.Controllers
{
    public class EmailController : ApiController
    {
        // GET: api/Email
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Email/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Email
        [ResponseType(typeof(EmailApiModel))]
        public IHttpActionResult PostPerformance(EmailApiModel emailApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = new EmailService();
            try
            {
                service.SendEmail(emailApiModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        // PUT: api/Email/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Email/5
        public void Delete(int id)
        {
        }
    }
}
