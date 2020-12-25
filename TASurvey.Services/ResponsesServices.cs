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
    public class ResponsesServices : IResponsesServices
    {
        private readonly TASurveyContext _context;

        public ResponsesServices(TASurveyContext context)
        {
            _context = context;
        }

        #region responses
        

        public async Task<List<Response>> GetResponses()
        {
            return _context.Responses.ToList();
        }

        public async Task<Response> GetResponseByID(int prmResponseID)
        {
            return _context.Responses.Find(prmResponseID);
        }

        public async Task<Response> SetResponse(Response prmResponse)
        {
            try
            {
                _context.Responses.Update(prmResponse);
                _context.SaveChanges();
                return prmResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Response> CreateResponse(Response prmResponse)
        {
            try
            {
                _context.Responses.Add(prmResponse);
                _context.SaveChanges();
                return prmResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteResponse(Response prmResponse)
        {
            try
            {
                _context.Responses.Remove(prmResponse);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region survey responses
        public async Task<List<SurveyResponse>> GetSurveyResponses()
        {
            return _context.SurveyResponses.ToList();
        }

        public async Task<SurveyResponse> GetSurveyResponseByID(int prmSurveyResponseID)
        {
            return _context.SurveyResponses.Find(prmSurveyResponseID);
        }

        public async Task<SurveyResponse> SetSurveyResponse(SurveyResponse prmSurveyResponse)
        {
            try
            {
                _context.SurveyResponses.Update(prmSurveyResponse);
                _context.SaveChanges();
                return prmSurveyResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SurveyResponse> CreateSurveyResponse(SurveyResponse prmSurveyResponse)
        {
            try
            {
                _context.SurveyResponses.Add(prmSurveyResponse);
                _context.SaveChanges();
                return prmSurveyResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteSurveyResponse(SurveyResponse prmSurveyResponse)
        {
            try
            {
                _context.SurveyResponses.Remove(prmSurveyResponse);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
