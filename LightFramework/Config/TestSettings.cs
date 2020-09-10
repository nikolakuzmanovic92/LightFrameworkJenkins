using LightFramework.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightFramework.Config
{
    [JsonObject("testSettings")]
    public class TestSettings
    {

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("browser")]
        public BrowserType Browser { get; set; }

        [JsonProperty("testType")]
        public string TestType { get; set; }

        [JsonProperty("isRemoteDriver")]
        public string IsRemoteDriver { get; set; }

        [JsonProperty("autConnectionString")]
        public string AUTConnectionString { get; set; }
    }
}
