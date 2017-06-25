using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonRecognition.Models.Recognition
{
    public class RecogniseCandidate
    {
        [JsonProperty("subject_id")]
        public string SubjectId { get; set; }

        [JsonProperty("confidence")]
        public decimal Confidence { get; set; }

        [JsonProperty("enrollment_timestamp")]
        public string EnrollmentTimestamp { get; set; }
    }
}