using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonRecognition.Models.Recognition
{
    public class ViewSubjectResponseModel
    {
        public ViewSubjectResponseModel()
        {
            FaceIds = new List<FaceIdModel>();
            Errors = new List<KairosError>();
        }

        [JsonProperty("status")]
        public string Status { get; set;}

        [JsonProperty("face_ids")]
        public IList<FaceIdModel> FaceIds { get; set; }

        [JsonProperty("Errors")]
        public IList<KairosError> Errors { get; set; }
    }
}