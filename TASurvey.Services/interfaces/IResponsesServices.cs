using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TASurvey.model.Models;

namespace TASurvey.Services.interfaces
{
    public interface IResponsesServices
    {        
        //response
        Task<List<Response>> GetResponses();
        Task<Response> SetResponse(Response prmResponse);
        Task<Response> CreateResponse(Response prmResponse);
        Task<bool> DeleteResponse(Response prmResponse);

        //survey_response
        Task<List<SurveyResponse>> GetSurveyResponses();
        Task<SurveyResponse> SetSurveyResponse(SurveyResponse prmSurveyResponse);
        Task<SurveyResponse> CreateSurveyResponse(SurveyResponse prmSurveyResponse);
        Task<bool> DeleteSurveyResponse(SurveyResponse prmSurveyResponse);

    }
}
