using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PairingTest.Web.Services.Wrapper
{
    [DataContract]
    public class QuestionnaireResponse
    {
        [DataMember]
        public string QuestionnaireTitle { get; set; }
        [DataMember]
        public IList<string> QuestionsText { get; set; }
    }
}