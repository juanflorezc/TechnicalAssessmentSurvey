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
    public class UsersController : ControllerBase
    {
        public readonly IUsersServices usersServices;
        public UsersController(IUsersServices prmUsersServices)
        {
            usersServices = prmUsersServices;
        }
        #region CRUD Respondent
        [HttpGet]
        [Route("Respondent")]
        public Task<List<Respondent>> GetRespondents()
        {
            return usersServices.GetRespondents();
        }

        [HttpGet]
        [Route("RespondentById/{id}")]
        public Task<Respondent> GetRespondents(int id)
        {
            return usersServices.GetRespondentByID(id);
        }

        [HttpPost]
        [Route("Respondent")]
        public Task<List<Respondent>> CreateRespondents()
        {
            return usersServices.GetRespondents();
        }

        [HttpPut]
        [Route("Respondent")]
        public Task<List<Respondent>> UpdateRespondents()
        {
            return usersServices.GetRespondents();
        }

        [HttpDelete]
        [Route("Respondent")]
        public Task<List<Respondent>> DeleteRespondents()
        {
            return usersServices.GetRespondents();
        }
        #endregion
    }
}
