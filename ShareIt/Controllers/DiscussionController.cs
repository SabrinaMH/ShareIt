using System;
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
    [RoutePrefix("discussion")]
    public class DiscussionController : ApiController
    {
        [Route("{discussionId}")]
        public HttpResponseMessage Post(Guid linkId, Guid discussionId, [FromBody] SubmitPostInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Provided data is invalid");                
            }

            var poster = new Poster(new Name(model.Poster.Name), new EmailAddress(model.Poster.Email));
            var submitPost = new SubmitPost(new LinkId(linkId), new DiscussionId(discussionId), poster, model.BodyText);
            Actors.LinkCoordinator.Tell(submitPost);
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
