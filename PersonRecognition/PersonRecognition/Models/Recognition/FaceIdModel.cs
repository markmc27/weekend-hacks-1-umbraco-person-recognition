using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonRecognition.Models.Recognition
{
    public class FaceIdModel
    {
        [JsonProperty("face_id")]
        public string FaceId { get; set; }
    }
}