using GifAtMe.Service.DTOs;
using GifAtMe.Service.Interfaces;
using GifAtMe.Service.Messaging;
using GifAtMe.Service.Messaging.GifEntries;
using System;
using System.Net.Http;
using System.Web.Http;

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
            ServiceResponseBase resp = _gifEntryService.GetAllGifEntries(new GetAllGifEntriesRequest(String.Empty, String.Empty, String.Empty));
            return Request.BuildResponse(resp);
        }

        // GET: api/gifentries/abc123?uidsource=slack
        [Route("{userId}")]
        public HttpResponseMessage GetGifEntries(string userId, string uIdSource = "")
        {
            ServiceResponseBase resp = _gifEntryService.GetAllGifEntries(new GetAllGifEntriesRequest(userId, uIdSource, String.Empty));
            return Request.BuildResponse(resp);
        }

        // GET: api/gifentries/u12345/highfive
        [Route("{userId}/{keyword}")]
        public HttpResponseMessage GetGifEntries(string userId, string keyword, string uIdSource = "")
        {
            ServiceResponseBase resp = _gifEntryService.GetAllGifEntries(new GetAllGifEntriesRequest(userId, uIdSource, keyword));
            return Request.BuildResponse(resp);
        }

        // GET: api/gifentries/u12345/thisguy/2
        [Route("{userId}/{keyword}/{alternateIndex}")]
        public HttpResponseMessage GetGifEntry(string userId, string keyword, int alternateIndex, string uIdSource = "")
        {
            ServiceResponseBase resp = _gifEntryService.GetGifEntry(new GetGifEntryRequest(userId, uIdSource, keyword, alternateIndex));
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

        // PUT: api/gifentries/u12345/highfive
        /*[Route("{id:int}")]
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
                    UserId = gifEntry.UserId,
                    Keyword = gifEntry.Keyword,
                    Url = gifEntry.Url,
                    AlternateIndex = gifEntry.AlternateIndex
                }
            };

            ServiceResponseBase resp = _gifEntryService.UpdateGifEntry(req);
            return Request.BuildResponse(resp);
        }

        // PUT: api/gifentries/u12345/highfive
        [Route("{userId}/{keyword}/{alternateIndex}")]
        public HttpResponseMessage PutGifEntry(string userId, string keyword, int alternateIndex, GifEntryDTO gifEntry)
        {
            if (!ModelState.IsValid)
            {
                ServiceResponseBase exResp = new UpdateGifEntryResponse();
                exResp.Exception = new ArgumentException("ModelState invalid.");
                return Request.BuildResponse(exResp);
            }

            UpdateGifEntryRequest req = new UpdateGifEntryRequest(userId, keyword, alternateIndex)
            {
                GifEntryProperties = new GifEntryDTOProperties()
                {
                    UserId = gifEntry.UserId,
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
        [Route("{UserId}/{keyword}/{alternateIndex}")]
        public HttpResponseMessage DeleteGifEntry(GifEntryDTO gifEntry)
        {
            DeleteGifEntryResponse deleteGifEntryResponse = _gifEntryService.DeleteGifEntry(new DeleteGifEntryRequest(gifEntry.UserId, gifEntry.Keyword, gifEntry.AlternateIndex));
            return Request.BuildResponse(deleteGifEntryResponse);
        }*/
    }
}