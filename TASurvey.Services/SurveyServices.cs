using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TASurvey.model.Models;
using TASurvey.Services.interfaces;

namespace TASurvey.Services
{
    public class SurveyServices : ISurveyServices
    {
        private readonly TASurveyContext _context;

        public SurveyServices(TASurveyContext context)
        {
            _context = context;
        }

        public async Task<Question> CreateQuestion(Question prmQuestion)
        {         
            try
            {
                _context.Questions.Add(prmQuestion);
                return prmQuestion;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

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

        public Task<List<Question>> GetQuestions()
        {
            return _context.Questions.ToListAsync();
        }

        public async Task<Question> setQuestion(Question prmQuestion)
        {
            try
            {
                _context.Questions.Update(prmQuestion);
                return prmQuestion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
