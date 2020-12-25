using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TASurvey.model.Models;

namespace TASurvey.Services.interfaces
{
    public interface IUsersServices
    {        
        //respondent
        Task<List<Respondent>> GetRespondents();
        Task<Respondent> GetRespondentByID(int RespondentID);
        Task<Respondent> SetRespondent(Respondent prmRespondent);
        Task<Respondent> CreateRespondent(Respondent prmRespondent);
        Task<bool> DeleteRespondent(Respondent prmRespondent);
           

    }
}
