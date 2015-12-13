using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShareIt.Controllers.Models;
using ShareIt.DiscussionCtx.Commands;

namespace ShareIt.Controllers
{
    [RoutePrefix("discussion")]
    public class DiscussionController : BaseController
    {
        [Route("{discussionId}")]
        public HttpResponseMessage Post(Guid discussionId, [FromBody] SubmitPostInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Provided data is invalid");                
            }

            var submitPost = new SubmitPost(discussionId, model.Poster.Name, model.Poster.Email, model.BodyText);
            _bus.Send(submitPost);
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
