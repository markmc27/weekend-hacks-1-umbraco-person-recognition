using PersonRecognition.Models;
using PersonRecognition.Models.Api;
using PersonRecognition.Models.Recognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.WebApi;

namespace PersonRecognition.Controllers.Api
{
    public class RecognitionController: UmbracoApiController
    {
        [HttpPost]
        public async Task<FindPersonResponse> FindPerson([FromBody] FindPersonRequest model)
        {
            var client = new KairosClient();

            var clientResponse = await client.Recognise(new RecogniseRequestModel
            {
                Image = model.Image,
                GalleryName = "MyGallery"
            });

            var subjectId = CheckCandidates(clientResponse);

            var matchedMember = Services.MemberService.GetMembersByPropertyValue("subjectId", subjectId).FirstOrDefault();
            if (matchedMember == null)
            {
                return new FindPersonResponse { IsSuccess = false };
            }
            //var mark = ApplicationContext.Current.Services.MemberService.GetMembersByPropertyValue("subjectId", "Mark").FirstOrDefault();
            //var someMedia = new UmbracoHelper(Umbraco.UmbracoContext).TypedMedia(mark.GetValue("initialImage"));
            var personResponse = new FindPersonResponse
            {
                ImageUrl = new UmbracoHelper(Umbraco.UmbracoContext).TypedMedia(matchedMember.GetValue("initialImage"))?.Url,
                GreetingText = matchedMember.GetValue<string>("greetingMessage"),
                IsSuccess = true
            };

            return personResponse;
        }

        private string CheckCandidates(RecogniseResponseModel data)
        {
            if(!data.Images.Any() || !data.Images.First().Candidates.Any())
            {
                return "";
            }

            var bestCandidate = data.Images.First().Candidates.OrderByDescending(c => c.Confidence).First();

            return bestCandidate.SubjectId;
        }
    }
}