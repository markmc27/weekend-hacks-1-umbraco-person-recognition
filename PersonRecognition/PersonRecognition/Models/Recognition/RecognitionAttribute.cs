using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonRecognition.Models.Recognition
{
    public class RecognitionAttribute
    {
        [JsonProperty("lips")]
        public string Lips { get; set; }

        [JsonProperty("asian")]
        public decimal AsianConfidence { get; set; }

        [JsonProperty("gender")]
        public GenderConfidence Gender {get;set;}

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("hispanic")]
        public decimal Hispanic { get; set; }

        [JsonProperty("other")]
        public decimal Other { get; set; }

        [JsonProperty("black")]
        public decimal Black { get; set; }

        [JsonProperty("white")]
        public decimal White { get; set; }

        [JsonProperty("glasses")]
        public string Glasses { get; set; }
    }
}