using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonRecognition.Models.Recognition
{
    public class GenderConfidence
    {
        [JsonProperty("femaleConfidence")]
        public decimal FemaleConfidence { get; set; }

        [JsonProperty("maleConfidence")]
        public decimal MaleConfidence { get; set; }

        [JsonProperty("type")]
        public string GenderType { get; set; }
    }
}