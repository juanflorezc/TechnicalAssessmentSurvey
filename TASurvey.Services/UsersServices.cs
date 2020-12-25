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
    public class UsersServices : IUsersServices
    {
        private readonly TASurveyContext _context;

        public UsersServices(TASurveyContext context)
        {
            _context = context;
        }

        #region respondent       

        /// <summary>
        /// get a list of all respondents
        /// </summary>
        /// <returns>list of respondents</returns>
       public async Task<List<Respondent>> GetRespondents()
        {
            return _context.Respondents.ToList();
        }
        /// <summary>
        /// get a respondent searching by id
        /// </summary>
        /// <returns>respondent</returns>

       public async Task<Respondent> GetRespondentByID(int prmRespondentID)
        {
            return _context.Respondents.Find(prmRespondentID);
        }

       public async Task<Respondent> SetRespondent(Respondent prmRespondent)
        {
            try
            {
                _context.Respondents.Update(prmRespondent);
                _context.SaveChanges();
                return prmRespondent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public async Task<Respondent> CreateRespondent(Respondent prmRespondent)
        {
            try
            {
                _context.Respondents.Add(prmRespondent);
                _context.SaveChanges();
                return prmRespondent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public async Task<bool> DeleteRespondent(Respondent prmRespondent)
        {
            try
            {
                _context.Respondents.Remove(prmRespondent);
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
