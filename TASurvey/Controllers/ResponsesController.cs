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
    public class ResponsesController : ControllerBase
    {
        public readonly IResponsesServices responsesServices;
        private readonly ILogger _logger;
        public ResponsesController(IResponsesServices prmResponseServices, ILogger<ResponsesController> logger)
        {
            responsesServices = prmResponseServices;
            _logger = logger;
        }

        #region CRUD survey_response
        [HttpGet]
        [Route("SurveyResponse")]
        public Task<List<SurveyResponse>> GetSurveyResponses()
        {
            return responsesServices.GetSurveyResponses();
        }


        [HttpPost]
        [Route("SurveyResponse")]
        public async Task<IActionResult> CreateSurveyResponses(SurveyResponse prmSurveyResponse)
        {
            try
            {
                var response = await responsesServices.CreateSurveyResponse(prmSurveyResponse);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.ExeptionError, ex, "Error Exception");
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("SurveyResponse")]
        public async Task<IActionResult> UpdateSurveyResponses(SurveyResponse prmSurveyResponse)
        {
            try
            {
                var response = await responsesServices.SetSurveyResponse(prmSurveyResponse);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.ExeptionError, ex, "Error Exception");
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("SurveyResponse")]
        public async Task<IActionResult> DeleteSurveyResponses(SurveyResponse prmSurveyResponse)
        {
            try
            {
                var response = await responsesServices.DeleteSurveyResponse(prmSurveyResponse);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.ExeptionError, ex, "Error Exception");
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region CRUD response
        [HttpGet]
        [Route("Response")]
        public Task<List<Response>> GetResponses()
        {
            return responsesServices.GetResponses();
        }


        [HttpPost]
        [Route("Response")]
        public async Task<IActionResult> CreateResponses(Response prmResponse)
        {
            try
            {
                var response = await responsesServices.CreateResponse(prmResponse);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.ExeptionError, ex, "Error Exception");
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("Response")]
        public async Task<IActionResult> UpdateResponses(Response prmResponse)
        {
            try
            {
                var response = await responsesServices.SetResponse(prmResponse);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.ExeptionError, ex, "Error Exception");
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("Response")]
        public async Task<IActionResult> DeleteResponses(Response prmResponse)
        {
            try
            {
                var response = await responsesServices.DeleteResponse(prmResponse);
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
