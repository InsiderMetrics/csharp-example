using InsiderMetrics.Docs.CodeExample.CSharp.Helpers;
using InsiderMetrics.Docs.CodeExample.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InsiderMetrics.Docs.CodeExample.CSharp.Repository
{
    public abstract class BaseRepository
    {
        private readonly string _baseUrl = "http://app.insidermetrics.io";
        private readonly string _apiVersion = "V1.0";
        private string _username;
        private string _password;

        public BaseRepository(string userName, string passWord)
        {
            this._username = userName;
            this._password = passWord;
        }

        public async Task<AuthResponse<T>> PostForCampaign<T>(string cultureinfo, string controller, string action, Guid campaignUniqueId, T entity) where T : IModel
        {
            var retour = new AuthResponse<T>();
            using (var client = new HttpClient())
            {
                // New code:
                client.BaseAddress = new Uri(this._baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                var encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(this._username.ToString() + ":" + MD5Hash(this._password.ToString())));
                client.DefaultRequestHeaders.Add("Authorization", "Credentials " + encoded);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST
                var response = await client.PostAsJsonAsync<T>(string.Format("/API/{0}/{1}/campaign/{2}/{3}/{4}", this._apiVersion, cultureinfo, campaignUniqueId, controller, action), entity);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    retour.Data = await response.Content.ReadAsAsync<T>();
                    retour.Status = HttpStatusCode.OK;
                }
                else
                {
                    retour.Error = response.ReasonPhrase;
                    retour.Status = response.StatusCode;
                }

                return retour;
            }
        }

        private string MD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
