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

        public Task<Question> CreateQuestion(Question prmQuestion)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteQuestion(Question )
        {
            throw new NotImplementedException();
        }

        public Task<List<Question>> GetQuestions()
        {
            return _context.Questions.ToListAsync();
        }

        public Task<Question> setQuestion(Question prmQuestion)
        {
            throw new NotImplementedException();
        }
    }
}
