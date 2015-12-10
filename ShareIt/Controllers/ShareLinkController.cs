using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShareIt.Controllers.Models;
using ShareIt.DiscussionCtx.Commands;
using ShareIt.DiscussionCtx.Domain;

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

            var link = new Link(new Uri(model.Link));
            IEnumerable<Receiver> receivers = model.EmailsOfReceivers.Select(x => new Receiver(new EmailAddress(x)));
            var emailOfSharer = new EmailAddress(model.EmailOfSharer);
            var nameOfSharer = new Name(model.NameOfSharer);
            var shareLink = new ShareLink(link, new Topic(model.Topic), emailOfSharer, nameOfSharer, new ListOfReceivers(receivers.ToArray()));
            _bus.Send(shareLink);
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}