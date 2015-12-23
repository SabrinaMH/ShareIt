using System;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using ShareIt.Controllers.Models;
using ShareIt.UserCtx.Commands;
using ShareIt.UserCtx.Domain;

namespace ShareIt.Controllers
{
    [RoutePrefix("user")]
    public class UserController : BaseController
    {
        [Route("")]
        public HttpResponseMessage Post([FromBody] RegisterUserInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Provided data is invalid");                
            }

            var isValidEmail = Regex.IsMatch(model.Email,
               @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
               @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
               RegexOptions.IgnoreCase);

            if (!isValidEmail)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Provided email format is invalid");                                
            }

            var registerUser = new RegisterUser(model.Name, model.Email);
            try
            {
                _bus.Send(registerUser);
            }
            catch (EmailAlreadyRegisteredException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Email already registered for a user");
            }

            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, model.Email);
            return response;
        }
    }
}