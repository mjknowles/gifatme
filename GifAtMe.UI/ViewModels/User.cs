using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GifAtMe.UI.ViewModels
{
    public class User
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}