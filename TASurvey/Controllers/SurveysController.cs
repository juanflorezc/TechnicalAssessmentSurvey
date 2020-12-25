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
        /// <summary>
        /// list the questions
        /// </summary>        
        /// <returns>list of questions</returns>
        [HttpGet]
        [Route("Question")]
        public Task<List<Question>> GetQuestions()
        {
            return surveyServices.GetQuestions();
        }

        /// <summary>
        /// Get a question by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>question</returns>
        [HttpGet]
        [Route("QuestionByID/{id}")]
        public Task<Question> GetQuestions(int id)
        {
            return surveyServices.GetQuestionByID(id);
        }

        /// <summary>
        /// create a question
        /// </summary>
        /// <param name="prmQuestion"></param>
        /// <returns>question created</returns>
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

        /// <summary>
        /// update a question
        /// </summary>
        /// <param name="prmQuestion"></param>
        /// <returns>question updated</returns>
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

        /// <summary>
        /// delete a question
        /// </summary>
        /// <param name="prmQuestion"></param>
        /// <returns>true if is sucessfull</returns>
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
        /// <summary>
        /// list surveys
        /// </summary>
        /// <returns>list</returns>
        [HttpGet]
        [Route("Survey")]
        public Task<List<Survey>> GetSurveys()
        {
            return surveyServices.GetSurveys();
        }

        /// <summary>
        /// get a survey by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>survey</returns>
        [HttpGet]
        [Route("SurveyByID/{id}")]
        public Task<Survey> GetSurveys(int id)
        {
            return surveyServices.GetSurveyByID(id);
        }

        /// <summary>
        /// create a survey
        /// </summary>
        /// <param name="prmSurvey"></param>
        /// <returns>survey created</returns>
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


        /// <summary>
        /// update survey
        /// </summary>
        /// <param name="prmSurvey"></param>
        /// <returns></returns>
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

        /// <summary>
        /// delete a survey
        /// </summary>
        /// <param name="prmSurvey"></param>
        /// <returns>true if is successfull</returns>
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
        /// <summary>
        /// get a list of question_order
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("QuestionOrder")]
        public Task<List<QuestionOrder>> GetQuestionOrders()
        {
            return surveyServices.GetQuestionOrders();
        }

        /// <summary>
        /// method to reorder the questions
        /// </summary>
        /// <param name="questionid"></param>
        /// <param name="order"></param>
        /// <returns>list of questionsorder</returns>
        [HttpPost]
        [Route("ReorderQuestionOrder/{questionid}/{order}")]
        public Task<List<QuestionOrder>> GetQuestionOrders(int questionid,int order)
        {
            return surveyServices.ReorderQuestionOrder(questionid,order);
        }

        /// <summary>
        /// create question order
        /// </summary>
        /// <param name="prmQuestionOrder"></param>
        /// <returns></returns>
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

        /// <summary>
        /// update question_order
        /// </summary>
        /// <param name="prmQuestionOrder"></param>
        /// <returns></returns>
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

        /// <summary>
        /// delete a question
        /// </summary>
        /// <param name="prmQuestionOrder"></param>
        /// <returns></returns>
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
