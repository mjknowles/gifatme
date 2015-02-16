﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Service.Messaging
{
    public abstract class ServiceResponseBase
    {
        public ServiceResponseBase()
        {
            this.Exception = null;
        }

        public Exception Exception { get; set; }
    }
}
