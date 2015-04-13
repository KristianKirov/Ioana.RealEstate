using Ioana.RealEstate.DataManipulation;
using Ioana.RealEstate.Models;
using Ioana.RealEstate.Models.Api;
using Ioana.RealEstate.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ioana.RealEstate.Controllers
{
    [Authorize]
    public class PhonesController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public async Task<IHttpActionResult> ValidatePhone([FromUri]ValidatePhoneRequest request)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            PhoneNormalizer phoneNormalizer = new PhoneNormalizer();
            string normalizedPhoneNumber = phoneNormalizer.Normalize(request.Phone);

            if (string.IsNullOrWhiteSpace(normalizedPhoneNumber))
            {
                return this.BadRequest("Invalid phone!");
            }

            ClientDataProvider clientDataProvider = new ClientDataProvider();
            if (!request.IncludeClientData)
            {
                int? clientId = await clientDataProvider.GetClientIdFromPhone(normalizedPhoneNumber);
                if (clientId == null)
                {
                    return this.StatusCode(HttpStatusCode.NoContent);
                }

                return this.BadRequest("Phone taken!");
            }
            else
            {
                ClientModel client = await clientDataProvider.GetClientFromPhone(normalizedPhoneNumber);
                if(client == null)
                {
                    return this.StatusCode(HttpStatusCode.NoContent);
                }

                return this.Ok(client);
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}