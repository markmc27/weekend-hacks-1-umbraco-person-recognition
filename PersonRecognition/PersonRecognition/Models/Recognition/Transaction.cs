using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonRecognition.Models.Recognition
{
    public class Transaction
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("gallery_name")]
        public string GalleryName { get; set; }

        [JsonProperty("confidence")]
        public decimal Confidence { get; set; }

        [JsonProperty("subject_id")]
        public string SubjectId { get; set; }

        [JsonProperty("face_id")]
        public int FaceId { get; set; }

    }
}