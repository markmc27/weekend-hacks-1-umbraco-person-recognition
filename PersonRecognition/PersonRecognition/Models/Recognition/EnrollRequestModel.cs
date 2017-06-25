using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonRecognition.Models.Recognition
{
    public class EnrollRequestModel
    {
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image as a base64-encoded image or a url.
        /// </value>
        [JsonProperty("image")]
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the subject identifier.
        /// </summary>
        /// <value>
        /// The subject identifier. Can be anything - only unique to a specific person (can upload 
        /// multiple images of same subject)
        /// </value>
        [JsonProperty("subject_id")]
        public string SubjectId { get; set; }

        /// <summary>
        /// Gets or sets the name of the gallery.
        /// </summary>
        /// <value>
        /// The name of the gallery.
        /// </value>
        [JsonProperty("gallery_name")]
        public string GalleryName { get; set; }
    }
}