using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace LogToJsonLocal
{
	// Testing
	// Remove prior to merging to master branch
	public class Program
	{
		public static void Main()
		{
			string lineEntry = @"192.168.88.238 RACHEL 80 [23/Sep/2019:22:23:25 +0000] ""GET / HTTP/1.1"" 200 4821 ""-"" ""Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.102 Safari/537.36 Edge/18.18362""";
			RowEntry ent = RowEntry.ParseLogEntryNginx(lineEntry);
			Console.WriteLine(ent.TimeLocal.ToString()); // 9/23/2019 10:23:25 PM
			Console.WriteLine(ent.RemoteAddress); // 192.168.88.238
			Console.WriteLine(ent.RemoteUser); // "-"
			Console.WriteLine(ent.Request); // "GET / HTTP/1.1"
			Console.WriteLine(ent.BodyBytesSent); //4821
		}
	}
	
	// Could be replaced with System.Text.Json most likely
    // May also be better as a struct
    public class RowEntry
    {
        [JsonProperty("time_local")]
        public DateTime TimeLocal { get; set; }

        [JsonProperty("remote_addr")]
        public string RemoteAddress { get; set; }

        [JsonProperty("remote_user")]
        public string RemoteUser { get; set; }

        [JsonProperty("request")]
        public string Request { get; set; }
		
		[JsonProperty("body_bytes_sent")]
		public long BodyBytesSent {get; set; }
		
		public string DeviceId { get; set; }
		
		private static string GetDeviceId(string blobName)
		{
			string[] blobSubStrings = blobName.Split('@', '.');
			if (blobSubStrings.Length >= 2)
			{
				return blobSubStrings[1];	
			}
			return "unknown";
		}
		
		private static DateTime GetDateTime(string timeEntry)
		{
			Dictionary<string, string> months = new Dictionary<string, string>();
			months.Add("Jan", "01");
			months.Add("Feb", "02");
			months.Add("Mar", "03");
			months.Add("Apr", "04");
			months.Add("May", "05");
			months.Add("Jun", "06");
			months.Add("Jul", "07");
			months.Add("Aug", "08");
			months.Add("Sep", "09");
			months.Add("Oct", "10");
			months.Add("Nov", "11");
			months.Add("Dec", "12");
			
			string format = "dd/MM/yyyy:HH:mm:ss";
			
			CultureInfo provider = CultureInfo.InvariantCulture;
			
			return DateTime.ParseExact(timeEntry.Substring(0, 3) + months[timeEntry.Substring(3, 3)] + timeEntry.Substring(6), format, provider);
		}
		
		
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
			RowEntry result = new RowEntry();
            
			string[] tokens = entry.Split(' ');
			
			result.TimeLocal = GetDateTime(tokens[3].Substring(1).Trim());
			result.RemoteAddress = tokens[0];
			result.RemoteUser = tokens[10];
			result.Request = tokens[5] + " " + tokens[6] + " " + tokens[7];
			result.BodyBytesSent = Convert.ToInt64(tokens[9]);
			result.DeviceId = GetDeviceId(""); //not sure where to obtain device ID from
			
			return result;
        }
    }
}
