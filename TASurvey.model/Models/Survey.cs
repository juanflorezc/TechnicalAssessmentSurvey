using System;
using System.Collections.Generic;

#nullable disable

namespace TASurvey.model.Models
{
    public partial class Survey
    {
        public Survey()
        {
            QuestionOrders = new HashSet<QuestionOrder>();
            SurveyResponses = new HashSet<SurveyResponse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Updated { get; set; }

        public virtual ICollection<QuestionOrder> QuestionOrders { get; set; }
        public virtual ICollection<SurveyResponse> SurveyResponses { get; set; }
    }
}
