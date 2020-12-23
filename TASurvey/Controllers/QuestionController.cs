using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TASurvey.model.Models;
using TASurvey.Services.interfaces;

namespace TASurvey.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        public readonly ISurveyServices surveyServices;
        public QuestionController(ISurveyServices prmSurveyServices)
        {
            surveyServices = prmSurveyServices;
        }

        [HttpGet]
        public Task<List<Question>> GetQuestions()
        {
            return surveyServices.GetQuestions();
        }

        [HttpPost]
        public Task<List<Question>> CreateQuestions()
        {
            return surveyServices.GetQuestions();
        }

        [HttpPut]
        public Task<List<Question>> UpdateQuestions()
        {
            return surveyServices.GetQuestions();
        }

        [HttpDelete]
        public Task<List<Question>> DeleteQuestions()
        {
            return surveyServices.GetQuestions();
        }
    }
}
