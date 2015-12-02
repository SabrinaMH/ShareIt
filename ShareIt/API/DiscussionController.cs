using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShareIt.API.Models;
using ShareIt.DiscussionCtx.Domain;
using ShareIt.Infrastructure;

namespace ShareIt.API
{
    [RoutePrefix("discussion")]
    public class DiscussionController : ApiController
    {
        private readonly Bus _bus;

        public DiscussionController()
        {
            _bus = Bus.Instance;
        }

        [Route("{discussionId}")]
        public HttpResponseMessage Post(Guid discussionId, [FromBody] SubmitPostInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Provided data is invalid");                
            }

            var id = new DiscussionId(discussionId);
            var poster = new Poster(new Name(model.Poster.Name), new EmailAddress(model.Poster.Email));
            var submitPost = new SubmitPost(id, poster, model.BodyText);
            _bus.Send(submitPost);
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}