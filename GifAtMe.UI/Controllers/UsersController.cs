using GifAtMe.Service.Interfaces;
using GifAtMe.Service.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GifAtMe.UI.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IGifEntryService _gifEntryService;

        public UsersController(IGifEntryService gifEntryService)
        {
            if (gifEntryService == null) throw new ArgumentNullException("GifEntry service in GifEntry controller");
            _gifEntryService = gifEntryService;
        }

        // GET: api/users
        [Route("")]
        public HttpResponseMessage GetUsers()
        {
            ServiceResponseBase resp = _gifEntryService.GetAllGifEntryUsers();
            return Request.BuildResponse(resp);
        }
    }
}
