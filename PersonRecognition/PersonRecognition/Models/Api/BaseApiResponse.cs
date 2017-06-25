using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonRecognition.Models.Api
{
    public abstract class BaseApiResponse
    {
        public bool IsSuccess { get; set; }
    }
}