using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Akka.Actor;
using ShareIt.Controllers.Models;
using ShareIt.DiscussionCtx.Domain;
using ShareIt.DiscussionCtx.Messages;
using ShareIt.Infrastructure;

namespace ShareIt.Controllers
{
    [RoutePrefix("sharelink")]
    public class ShareLinkController : ApiController
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
            var sharer = new Sharer(nameOfSharer, emailOfSharer);
            var shareLink = new ShareLink(link, new Topic(model.Topic), sharer, new ListOfReceivers(receivers.ToArray()));
            Actors.LinkCoordinator.Tell(shareLink);
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}