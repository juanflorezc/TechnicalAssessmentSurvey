using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASurvey.model.Models;
using TASurvey.Services.interfaces;

namespace TASurvey.Services
{
    public class SurveysServices : ISurveysServices
    {
        private readonly TASurveyContext _context;

        public SurveysServices(TASurveyContext context)
        {
            _context = context;
        }

        #region questions
        /// <summary>
        /// Create questions
        /// </summary>
        /// <param name="prmQuestion"></param>
        /// <returns>question object</returns>
        public async Task<Question> CreateQuestion(Question prmQuestion)
        {
            try
            {
                _context.Questions.Add(prmQuestion);
                _context.SaveChanges();
                return prmQuestion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Dete questions 
        /// </summary>
        /// <param name="prmQuestion"></param>
        /// <returns>
        /// true when deleted </returns>
        public async Task<bool> DeleteQuestion(Question prmQuestion)
        {
            try
            {
                _context.Questions.Remove(prmQuestion);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// update question
        /// </summary>
        /// <param name="prmQuestion"></param>
        /// <returns>
        /// object question updated</returns>
        public async Task<Question> SetQuestion(Question prmQuestion)
        {
            try
            {
                var questionEdit = _context.Questions.Find(prmQuestion.Id);
                questionEdit.Text = prmQuestion.Text;
                _context.Questions.Update(questionEdit);
                _context.SaveChanges();
                return prmQuestion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        /// <summary>
        /// get a question by id
        /// </summary>
        /// <param name="QuestionID"></param>
        /// <returns>question</returns>
        public async Task<Question> GetQuestionByID(int QuestionID)
        {
            return _context.Questions.Find(QuestionID);
        }
        /// <summary>
        /// get a list of all questions
        /// </summary>
        /// <returns>list of questions</returns>
        public Task<List<Question>> GetQuestions()
        {
            return _context.Questions.ToListAsync();
        }

        #endregion

        #region question_order
        public async Task<QuestionOrder> CreateQuestionOrder(QuestionOrder prmQuestionOrder)
        {
            try
            {
                _context.QuestionOrders.Add(prmQuestionOrder);
                _context.SaveChanges();
                return prmQuestionOrder;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<QuestionOrder> SetQuestionOrder(QuestionOrder prmQuestionOrder)
        {
            try
            {                          
                _context.QuestionOrders.Update(prmQuestionOrder);
                _context.SaveChanges();
                return prmQuestionOrder;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> DeleteQuestionOrder(QuestionOrder prmQuestionOrder)
        {
            try
            {
                _context.QuestionOrders.Remove(prmQuestionOrder);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public async Task<List<QuestionOrder>> GetQuestionOrders()
        {
            return _context.QuestionOrders.ToList();
        }

        public async Task<List<QuestionOrder>> ReorderQuestionOrder(int prmQuestionID, int prmPosition)
        {
            return _context.QuestionOrders.FromSqlRaw($"EXEC [dbo].[proc_setreOrder] {0},{1}",prmQuestionID,prmPosition).ToList();
        }


        #endregion

        #region survey
        public async Task<Survey> CreateSurvey(Survey prmSurvey)
        {
            try
            {
                _context.Surveys.Update(prmSurvey);
                _context.SaveChanges();
                return prmSurvey;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Survey> SetSurvey(Survey prmSurvey)
        {
            try
            {
                var objEdit = _context.Surveys.Find(prmSurvey.Id);
                objEdit.Name = prmSurvey.Name;
                objEdit.Description = prmSurvey.Description;
                _context.Surveys.Update(objEdit);
                _context.SaveChanges();
                return prmSurvey;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> DeleteSurvey(Survey prmSurvey)
        {
            try
            {
                _context.Surveys.Remove(prmSurvey);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Survey> GetSurveyByID(int prmSurveyID)
        {
            return _context.Surveys.Find(prmSurveyID);
        }

        public async Task<List<Survey>> GetSurveys()
        {
            return _context.Surveys.ToList();
        }

        
        #endregion


    }
}
