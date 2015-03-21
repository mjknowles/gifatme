using GifAtMe.Service.DTOs;
using GifAtMe.Service.Implementations;
using GifAtMe.Service.Interfaces;
using GifAtMe.Service.Messaging;
using GifAtMe.Service.Messaging.GifEntries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GifAtMe.UI;

namespace GifAtMe.UI.Controllers
{
    [RoutePrefix("api/gifentries")]
    public class GifEntriesController : ApiController
    {
        private readonly IGifEntryService _gifEntryService;

        public GifEntriesController(IGifEntryService gifEntryService)
        {
            if (gifEntryService == null) throw new ArgumentNullException("GifEntry service in GifEntry controller");
            _gifEntryService = gifEntryService;
        }

        // GET: api/gifentries
        [Route("")]
        public HttpResponseMessage GetGifEntries()
        {
            ServiceResponseBase resp = _gifEntryService.GetAllGifEntries(new GetAllGifEntriesRequest(String.Empty, String.Empty));
            return Request.BuildResponse(resp);
        }

        // GET: api/gifentries/mknowles
        [Route("{userName}")]
        public HttpResponseMessage GetGifEntries(string userName)
        {
            ServiceResponseBase resp = _gifEntryService.GetAllGifEntries(new GetAllGifEntriesRequest(userName, String.Empty));
            return Request.BuildResponse(resp);
        }

        // GET: api/gifentries/mknowles
        [Route("{userName}/{keyword}")]
        public HttpResponseMessage GetGifEntries(string userName, string keyword)
        {
            ServiceResponseBase resp = _gifEntryService.GetAllGifEntries(new GetAllGifEntriesRequest(userName, keyword));
            return Request.BuildResponse(resp);
        }

        // GET: api/gifentries/mknowles/thisguy
        // GET: api/gifentries/mknowles/thisguy/2
        [Route("{userName}/{keyword}/{alternateIndex}")]
        public HttpResponseMessage GetGifEntry(string userName, string keyword, int alternateIndex)
        {
            ServiceResponseBase resp = _gifEntryService.GetGifEntry(new GetGifEntryRequest(userName, keyword, alternateIndex));
            return Request.BuildResponse(resp);
        }
        
        // GET: api/gifentries/5
        [Route("{id:int}")]
        public HttpResponseMessage GetGifEntry(int id)
        {
            ServiceResponseBase resp = _gifEntryService.GetGifEntry(new GetGifEntryRequest(id));
            return Request.BuildResponse(resp);
        }
        
        // POST: api/gifentries
        [Route("")]
        public HttpResponseMessage PostGifEntry(GifEntryDTOProperties gifEntry)
        {
            if (!ModelState.IsValid)
            {
                ServiceResponseBase exResp = new InsertGifEntryResponse();
                exResp.Exception = new ArgumentException("ModelState invalid.");
                return Request.BuildResponse(exResp);
            }

            InsertGifEntryResponse insertGifEntryResponse = _gifEntryService.InsertGifEntry(
                new InsertGifEntryRequest() { GifEntryDTOProperties = gifEntry });
            return Request.BuildResponse(insertGifEntryResponse);
        }

        // PUT: api/gifentries/mknowles/highfive
        // PUT: api/gifentries/mknowles/highfive
        [Route("{id:int}")]
        public HttpResponseMessage PutGifEntry(GifEntryDTO gifEntry)
        {
            if (!ModelState.IsValid)
            {
                ServiceResponseBase exResp = new UpdateGifEntryResponse();
                exResp.Exception = new ArgumentException("ModelState invalid.");
                return Request.BuildResponse(exResp);
            }

            UpdateGifEntryRequest req = new UpdateGifEntryRequest(gifEntry.Id)
            {
                GifEntryProperties = new GifEntryDTOProperties()
                {
                    UserName = gifEntry.UserName,
                    Keyword = gifEntry.Keyword,
                    Url = gifEntry.Url,
                    AlternateIndex = gifEntry.AlternateIndex
                }
            };

            ServiceResponseBase resp = _gifEntryService.UpdateGifEntry(req);
            return Request.BuildResponse(resp);
        }

        // PUT: api/gifentries/mknowles/highfive
        // PUT: api/gifentries/mknowles/highfive
        [Route("{userName}/{keyword}/{alternateIndex}")]
        public HttpResponseMessage PutGifEntry(string userName, string keyword, int alternateIndex, GifEntryDTO gifEntry)
        {
            if (!ModelState.IsValid)
            {
                ServiceResponseBase exResp = new UpdateGifEntryResponse();
                exResp.Exception = new ArgumentException("ModelState invalid.");
                return Request.BuildResponse(exResp);
            }

            UpdateGifEntryRequest req = new UpdateGifEntryRequest(userName, keyword, alternateIndex)
            {
                GifEntryProperties = new GifEntryDTOProperties()
                {
                    UserName = gifEntry.UserName,
                    Keyword = gifEntry.Keyword,
                    Url = gifEntry.Url,
                    AlternateIndex = gifEntry.AlternateIndex
                }
            };

            ServiceResponseBase resp = _gifEntryService.UpdateGifEntry(req);
            return Request.BuildResponse(resp);
        }

        // DELETE: api/gifentries/5
        [Route("{id:int}")]
        public HttpResponseMessage DeleteGifEntry(int id)
        {
            DeleteGifEntryResponse deleteGifEntryResponse = _gifEntryService.DeleteGifEntry(new DeleteGifEntryRequest(id));
            return Request.BuildResponse(deleteGifEntryResponse);
        }

        // DELETE: api/gifentries/mknowles/highfive
        // DELETE: api/gifentries/mknowles/highfive/2
        [Route("{userName}/{keyword}/{alternateIndex}")]
        public HttpResponseMessage DeleteGifEntry(GifEntryDTO gifEntry)
        {
            DeleteGifEntryResponse deleteGifEntryResponse = _gifEntryService.DeleteGifEntry(new DeleteGifEntryRequest(gifEntry.UserName, gifEntry.Keyword, gifEntry.AlternateIndex));
            return Request.BuildResponse(deleteGifEntryResponse);
        }
    }
}