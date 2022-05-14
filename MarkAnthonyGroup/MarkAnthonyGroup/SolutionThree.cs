using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace MarkAnthonyGroup
{
    public class WebClient
    {
        private WebRequest request;
        private string responseData;

        public WebClient(string url)
        {
            request = WebRequest.Create(url);
            GetResponseData();
        }

        public string ResponseData => responseData;

        private string GetResponseData()
        {
            using (WebResponse response = request.GetResponse())
            {
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    responseData = reader.ReadToEnd();
                }
            }
            return responseData;
        }
    }

    public class AgeRangeCounter
    {
        private List<int> ages;

        public AgeRangeCounter(string data)
        {
            ParseData(data);
        }

        private void ParseData(string data)
        {
            ages = new List<int>();
            string[] dataValues = data.Split(':')[1].Replace("\"", "").Replace("}", "").Replace(" ", "").Split(',');
            for (int i = 0; i < dataValues.Length; i++)
            {
                var keyValueArray = dataValues[i].Split('=');
                int value = 0;
                if (Int32.TryParse(keyValueArray[1], out value))
                {
                    ages.Add(value);
                }
            }

            //TODO: Parse json using Newtonsoft.Json and deserialize response into KeyValuePair.
        }

        public int? Count(int minimumAge)
        {
            return ages?.Where(x => x >= minimumAge)?.Count();
        }
    }
}
