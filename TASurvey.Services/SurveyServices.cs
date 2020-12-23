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
        public Task<List<Question>> GetQuestions()
        {
            return _context.Questions.ToListAsync();
        }
    }
}
