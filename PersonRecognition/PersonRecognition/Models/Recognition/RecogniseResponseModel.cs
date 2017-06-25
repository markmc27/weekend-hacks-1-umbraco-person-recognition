using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonRecognition.Models.Recognition
{
    public class RecogniseResponseModel
    {
        public RecogniseResponseModel()
        {
            Images = new List<EnrollImage>();
        }

        [JsonProperty("face_id")]
        public string FaceId { get; set; }

        [JsonProperty("images")]
        public IList<EnrollImage> Images { get; set; }
    }
}