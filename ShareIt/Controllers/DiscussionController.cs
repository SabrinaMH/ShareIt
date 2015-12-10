using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShareIt.Controllers.Models;
using ShareIt.DiscussionCtx.Commands;
using ShareIt.DiscussionCtx.Domain;
using ShareIt.Infrastructure;

namespace ShareIt.Controllers
{
    [RoutePrefix("discussion")]
    public class DiscussionController : BaseController
    {
        [Route("{discussionId}")]
        public HttpResponseMessage Post(string linkId, Guid discussionId, [FromBody] SubmitPostInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Provided data is invalid");                
            }

            var poster = new Poster(new Name(model.Poster.Name), new EmailAddress(model.Poster.Email));
            var submitPost = new SubmitPost(new LinkId(linkId), new DiscussionId(discussionId), poster, model.BodyText);
            _bus.Send(submitPost);
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
