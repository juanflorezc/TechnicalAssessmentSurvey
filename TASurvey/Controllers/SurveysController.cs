using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TASurvey.Helpers;
using TASurvey.model.Models;
using TASurvey.Services.interfaces;

namespace TASurvey.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveysController : ControllerBase
    {
        public readonly ISurveysServices surveyServices;
        private readonly ILogger _logger;

        public SurveysController(ISurveysServices prmSurveyServices, ILogger<ResponsesController> logger)
        {
            surveyServices = prmSurveyServices;
            _logger = logger;
        }

        #region CRUD question
        [HttpGet]
        [Route("Question")]
        public Task<List<Question>> GetQuestions()
        {
            return surveyServices.GetQuestions();
        }

        [HttpGet]
        [Route("QuestionByID/{id}")]
        public Task<Question> GetQuestions(int id)
        {
            return surveyServices.GetQuestionByID(id);
        }

        [HttpPost]
        [Route("Question")]
        public async Task<IActionResult> CreateQuestions(Question prmQuestion)
        {
            try
            {
                var response = await surveyServices.CreateQuestion(prmQuestion);
                return Ok(response);
            }
            catch (Exception ex)
            {               
                _logger.LogWarning(LogEvents.ExeptionError, ex, "Error Exception");
                return BadRequest(ex.ToString());
            }            
        }

        [HttpPut]
        [Route("Question")]
        public async Task<IActionResult> UpdateQuestions(Question prmQuestion)
        {
            try
            {
                var response = await surveyServices.SetQuestion(prmQuestion);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.ExeptionError, ex, "Error Exception");
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("Question")]
        public async Task<IActionResult> DeleteQuestions(Question prmQuestion)
        {
            try
            {
                var response = await surveyServices.DeleteQuestion(prmQuestion);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.ExeptionError, ex, "Error Exception");
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region CRUD survey
        [HttpGet]
        [Route("Survey")]
        public Task<List<Survey>> GetSurveys()
        {
            return surveyServices.GetSurveys();
        }

        [HttpGet]
        [Route("SurveyByID/{id}")]
        public Task<Survey> GetSurveys(int id)
        {
            return surveyServices.GetSurveyByID(id);
        }

        [HttpPost]
        [Route("Survey")]
        public async Task<IActionResult> CreateSurveys(Survey prmSurvey)
        {
            try
            {
                var response = await surveyServices.CreateSurvey(prmSurvey);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.ExeptionError, ex, "Error Exception");
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("Survey")]
        public async Task<IActionResult> UpdateSurveys(Survey prmSurvey)
        {
            try
            {
                var response = await surveyServices.SetSurvey(prmSurvey);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.ExeptionError, ex, "Error Exception");
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("Survey")]
        public async Task<IActionResult> DeleteSurveys(Survey prmSurvey)
        {
            try
            {
                var response = await surveyServices.DeleteSurvey(prmSurvey);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.ExeptionError, ex, "Error Exception");
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region Question_order
        [HttpGet]
        [Route("QuestionOrder")]
        public Task<List<QuestionOrder>> GetQuestionOrders()
        {
            return surveyServices.GetQuestionOrders();
        }

        
        [HttpPost]
        [Route("QuestionOrder")]
        public async Task<IActionResult> CreateQuestionOrders(QuestionOrder prmQuestionOrder)
        {
            try
            {
                var response = await surveyServices.CreateQuestionOrder(prmQuestionOrder);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.ExeptionError, ex, "Error Exception");
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("QuestionOrder")]
        public async Task<IActionResult> UpdateQuestionOrders(QuestionOrder prmQuestionOrder)
        {
            try
            {
                var response = await surveyServices.SetQuestionOrder(prmQuestionOrder);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.ExeptionError, ex, "Error Exception");
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("QuestionOrder")]
        public async Task<IActionResult> DeleteQuestionOrders(QuestionOrder prmQuestionOrder)
        {
            try
            {
                var response = await surveyServices.DeleteQuestionOrder(prmQuestionOrder);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.ExeptionError, ex, "Error Exception");
                return BadRequest(ex.ToString());
            }
        }
        #endregion
    }
}
