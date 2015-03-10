using InsiderMetrics.Docs.CodeExample.CSharp.Helpers;
using InsiderMetrics.Docs.CodeExample.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsiderMetrics.Docs.CodeExample.CSharp.Repository
{
    public class RespondentRepository : BaseRepository
    {
        public RespondentRepository(string username, string password) 
            : base (username, password)
        {

        }

        public async Task<AuthResponse<Respondent>> Add(string cultureinfo, Guid campaignUniqueId, Respondent entity)
        {
            return await base.PostForCampaign<Respondent>(cultureinfo, "Respondent", "Add", campaignUniqueId, entity);
        }
    }
}
