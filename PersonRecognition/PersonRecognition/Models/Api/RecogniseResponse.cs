using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonRecognition.Models.Api
{
    public class FindPersonResponse: BaseApiResponse
    {
        public string ImageUrl { get; set; }

        public string GreetingText { get; set; }
    }
}