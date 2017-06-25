using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonRecognition.Models.Recognition
{
    public class ViewSubjectRequestModel
    {
        [JsonProperty("gallery_name")]
        public string GalleryName { get; set; }

        [JsonProperty("subject_id")]
        public string SubjectId { get; set; }
    }
}