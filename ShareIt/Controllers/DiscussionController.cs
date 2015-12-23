using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ShareIt.Controllers.Models;
using ShareIt.DiscussionCtx.Commands;
using ShareIt.DiscussionCtx.Queries;
using ShareIt.ReadCtx.Models;

namespace ShareIt.Controllers
{
    [RoutePrefix("discussion")]
    public class DiscussionController : BaseController
    {
        [Route("{discussionId}")]
        [ResponseType(typeof(Discussion))]
        public HttpResponseMessage Get(Guid discussionId)
        {
            var discussionQueryHandler = new DiscussionQueryHandler();
            var discussionByIdQuery = new DiscussionByIdQuery(discussionId);
            discussionQueryHandler.Handle(discussionByIdQuery);
            return null;
        }

        [Route("{discussionId}")]
        public HttpResponseMessage Post(Guid discussionId, [FromBody] SubmitPostInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Provided data is invalid");                
            }

            var submitPost = new SubmitPost(discussionId, model.EmailOfPoster, model.BodyText);
            _bus.Send(submitPost);
            
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, discussionId.ToString());
            return response;
        }
    }
}
