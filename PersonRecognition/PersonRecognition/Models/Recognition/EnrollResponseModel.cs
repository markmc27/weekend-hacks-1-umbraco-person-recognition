using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonRecognition.Models.Recognition
{
    public class EnrollResponseModel
    {
        public EnrollResponseModel()
        {
            Images = new List<EnrollImage>();
        }

        [JsonProperty("face_id")]
        public string FaceId { get; set; }

        [JsonProperty("images")]
        public IList<EnrollImage> Images { get; set; }
    }
}