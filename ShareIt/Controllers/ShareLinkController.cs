using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShareIt.Controllers.Models;
using ShareIt.LinkCtx.Commands;

namespace ShareIt.Controllers
{
    [RoutePrefix("sharelink")]
    public class ShareLinkController : BaseController
    {
        [Route("")]
        public HttpResponseMessage Post([FromBody] ShareLinkInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Provided data is invalid");
            }

            var shareLink = new ShareLink(model.Link, model.Topic, model.EmailOfSharer, model.EmailsOfReceivers);
            _bus.Send(shareLink);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            return response;
        }
    }
}