using PersonRecognition.Models.Recognition;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace PersonRecognition.Events
{
    public class MemberEventHandler : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            MemberService.Saved += MemberService_Saved;
        }

        private void MemberService_Saved(IMemberService sender, SaveEventArgs<IMember> e)
        {
            foreach (IMember member in e.SavedEntities)
            {
                var subjectId = member.GetValue<string>("subjectId");
                if (subjectId == null)
                {
                    return;
                }

                var kairosClient = new KairosClient();
                if (!kairosClient.CheckPerson(subjectId))
                {
                    //todo: instead of using e.SavedEntities, use sender to get the member and then get its values instead!
                    var initialMemberImage = new UmbracoHelper(UmbracoContext.Current).TypedMedia(member.GetValue("initialImage"));
                    var imageUrl = initialMemberImage.Url;

                    var enrollResult = System.Threading.Tasks.Task.Run(async () => await kairosClient.Enroll(new EnrollRequestModel
                        {
                            SubjectId = subjectId,
                            GalleryName = "MyGallery",
                            Image = $"{ConfigurationManager.AppSettings["PublicUrl"]}{imageUrl}"
                        })
                    ).Result;
                }
            }

        }
    }

}