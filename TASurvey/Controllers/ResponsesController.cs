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
    public class ResponsesController : ControllerBase
    {
        public readonly IResponsesServices responsesServices;
        public ResponsesController(IResponsesServices prmResponseServices)
        {
            responsesServices = prmResponseServices;
        }

        #region CRUD survey_response
        [HttpGet]
        [Route("SurveyResponse")]
        public Task<List<SurveyResponse>> GetSurveyResponses()
        {
            return responsesServices.GetSurveyResponses();
        }

        [HttpGet]
        [Route("SurveyResponseById/{id}")]
        public Task<SurveyResponse> GetSurveyResponses(int id)
        {
            return responsesServices.GetSurveyResponseByID(id);
        }

        [HttpPost]
        [Route("SurveyResponse")]
        public Task<List<SurveyResponse>> CreateSurveyResponses()
        {
            return responsesServices.GetSurveyResponses();
        }

        [HttpPut]
        [Route("SurveyResponse")]
        public Task<List<SurveyResponse>> UpdateSurveyResponses()
        {
            return responsesServices.GetSurveyResponses();
        }

        [HttpDelete]
        [Route("SurveyResponse")]
        public Task<List<SurveyResponse>> DeleteSurveyResponses()
        {
            return responsesServices.GetSurveyResponses();
        }
        #endregion

        #region CRUD response
        [HttpGet]
        [Route("Response")]
        public Task<List<Response>> GetResponses()
        {
            return responsesServices.GetResponses();
        }

        [HttpGet]
        [Route("ResponseById/{id}")]
        public Task<Response> GetResponses(int id)
        {
            return responsesServices.GetResponseByID(id);
        }

        [HttpPost]
        [Route("Response")]
        public Task<List<Response>> CreateResponses()
        {
            return responsesServices.GetResponses();
        }

        [HttpPut]
        [Route("Response")]
        public Task<List<Response>> UpdateResponses()
        {
            return responsesServices.GetResponses();
        }

        [HttpDelete]
        [Route("Response")]
        public Task<List<Response>> DeleteResponses()
        {
            return responsesServices.GetResponses();
        }
        #endregion
    }
}
