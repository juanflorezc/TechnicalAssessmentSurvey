using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TASurvey.model.Models;

namespace TASurvey.Services.interfaces
{
    public interface ISurveyServices
    {
        Task<List<Question>> GetQuestions();
        Task<Question> setQuestion(Question prmQuestion);
        Task<Question> CreateQuestion(Question prmQuestion);
        Task<bool> DeleteQuestion(Question prmQuestion);
    }
}
