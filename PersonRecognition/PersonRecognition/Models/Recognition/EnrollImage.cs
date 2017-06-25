using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonRecognition.Models.Recognition
{
    public class EnrollImage
    {
        public EnrollImage()
        {
            Candidates = new List<RecogniseCandidate>();
        }

        [JsonProperty("attributes")]
        public RecognitionAttribute Attributes { get; set; }

        [JsonProperty("transaction")]
        public Transaction Transaction { get; set; }

        [JsonProperty("candidates")]
        public IList<RecogniseCandidate> Candidates { get; set; }
    }
}