using System;
using System.Collections.Generic;

#nullable disable

namespace TASurvey.model.Models
{
    public partial class SurveyResponse
    {
        public SurveyResponse()
        {
            Responses = new HashSet<Response>();
        }

        public int Id { get; set; }
        public int SurveyId { get; set; }
        public int RespondentId { get; set; }
        public byte[] Updated { get; set; }

        public virtual Respondent Respondent { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
    }
}
