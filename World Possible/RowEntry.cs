using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LogToJsonLocal
{

    // Could be replaced with System.Text.Json most likely
    // May also be better as a struct

    class RowEntry
    {
        [JsonProperty("time_local")]
        public DateTime TimeLocal { get; set; }

        [JsonProperty("remote_addr")]
        public string RemoteAddress { get; set; }

        [JsonProperty("remote_user")]
        public string RemoteUser { get; set; }

        [JsonProperty("request")]
        public string Request { get; set; }

        public static RowEntry DeserializeJson(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentException("json can not be null or empty.");
            }

            return JsonConvert.DeserializeObject<RowEntry>(json);
        }

        internal string ModuleName()
        {
            throw new NotImplementedException();
        }

        public static RowEntry ParseLogEntryNginx(string entry)
        {
            return null;
        }
    }
}
