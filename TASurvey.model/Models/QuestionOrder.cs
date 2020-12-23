using System;
using System.Collections.Generic;

#nullable disable

namespace TASurvey.model.Models
{
    public partial class QuestionOrder
    {
        public int QuestionId { get; set; }
        public int SurveyId { get; set; }
        public int Order { get; set; }

        public virtual Question Question { get; set; }
        public virtual Survey Survey { get; set; }
    }
}
