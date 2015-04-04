﻿using GifAtMe.Service.Messaging;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GifAtMe.UI
{
    public static class HttpResponseBuilder
    {
        public static HttpResponseMessage BuildResponse(this HttpRequestMessage requestMessage, ServiceResponseBase baseResponse)
        {
            HttpStatusCode statusCode = HttpStatusCode.OK;
            if (baseResponse.Exception != null)
            {
                statusCode = baseResponse.Exception.ConvertToHttpStatusCode();
                HttpResponseMessage message = new HttpResponseMessage(statusCode);
                message.Content = new StringContent(baseResponse.Exception.Message);
                throw new HttpResponseException(message);
            }
            return requestMessage.CreateResponse<ServiceResponseBase>(statusCode, baseResponse);
        }
    }
}