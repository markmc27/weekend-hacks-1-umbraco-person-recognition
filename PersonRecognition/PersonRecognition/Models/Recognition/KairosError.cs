using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonRecognition.Models.Recognition
{
    public class KairosError
    {
        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("ErrCode")]
        public string ErrorCode { get; set; }
    }
}