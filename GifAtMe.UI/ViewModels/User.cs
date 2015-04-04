using Newtonsoft.Json;

namespace GifAtMe.UI.ViewModels
{
    public class User
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}