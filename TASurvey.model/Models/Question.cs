using System;
using System.Collections.Generic;

#nullable disable

namespace TASurvey.model.Models
{
    public partial class Question
    {
        public Question()
        {
            QuestionOrders = new HashSet<QuestionOrder>();
            Responses = new HashSet<Response>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public byte[] Updated { get; set; }

        public virtual ICollection<QuestionOrder> QuestionOrders { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
    }
}
