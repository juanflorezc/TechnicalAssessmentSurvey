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
    public class UsersController : ControllerBase
    {
        public readonly IUsersServices usersServices;
        private readonly ILogger _logger;
        public UsersController(IUsersServices prmUsersServices, ILogger<ResponsesController> logger)
        {
            usersServices = prmUsersServices;
            _logger = logger;
        }
        #region CRUD Respondent
        /// <summary>
        /// get a list of respondents
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Respondent")]
        public Task<List<Respondent>> GetRespondents()
        {
            return usersServices.GetRespondents();
        }

        /// <summary>
        /// get a respondend by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("RespondentById/{id}")]
        public Task<Respondent> GetRespondents(int id)
        {
            return usersServices.GetRespondentByID(id);
        }

        /// <summary>
        /// create a respondend
        /// </summary>
        /// <param name="prmRespondent"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Respondent")]
        public async Task<IActionResult> CreateRespondents(Respondent prmRespondent)
        {
            try
            {
                var response = await usersServices.CreateRespondent(prmRespondent);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.ExeptionError, ex, "Error Exception");
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// update a respondendt
        /// </summary>
        /// <param name="prmRespondent"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Respondent")]
        public async Task<IActionResult> UpdateRespondents(Respondent prmRespondent)
        {
            try
            {
                var response = await usersServices.SetRespondent(prmRespondent);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.ExeptionError, ex, "Error Exception");
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// dete a respondent
        /// </summary>
        /// <param name="prmRespondent"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Respondent")]
        public async Task<IActionResult> DeleteRespondents(Respondent prmRespondent)
        {
            try
            {
                var response = await usersServices.DeleteRespondent(prmRespondent);
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
