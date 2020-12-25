using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TASurvey.model.Models;

namespace TASurvey.Services.interfaces
{
    public interface ISurveysServices
    {        
        //questions
        Task<List<Question>> GetQuestions();
        Task<Question> GetQuestionByID(int QuestionID);
        Task<Question> SetQuestion(Question prmQuestion);
        Task<Question> CreateQuestion(Question prmQuestion);
        Task<bool> DeleteQuestion(Question prmQuestion);
        //survey
        Task<List<Survey>> GetSurveys();
        Task<Survey> GetSurveyByID(int SurveyID);
        Task<Survey> SetSurvey(Survey prmSurvey);
        Task<Survey> CreateSurvey(Survey prmSurvey);
        Task<bool> DeleteSurvey(Survey prmSurvey);

        //question_order
        Task<List<QuestionOrder>> GetQuestionOrders();
        Task<QuestionOrder> GetQuestionOrderByID(int QuestionOrderID);
        Task<QuestionOrder> SetQuestionOrder(QuestionOrder prmQuestionOrder);
        Task<QuestionOrder> CreateQuestionOrder(QuestionOrder prmQuestionOrder);
        Task<bool> DeleteQuestionOrder(QuestionOrder prmQuestionOrder);       

    }
}
