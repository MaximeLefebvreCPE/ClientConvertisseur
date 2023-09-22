using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Machado_Lefebve_ClientConvertisseurV1.Models;
using Microsoft.UI.Xaml;

namespace Machado_Lefebve_ClientConvertisseurV1.Services
{
    public class WSService
    {
        private HttpClient client;
        public WSService(string uri)
        {
                client = new HttpClient();
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Devise>> GetDevisesAsync(string nomControleur)
        {
            try
            {
                return await client.GetFromJsonAsync<List<Devise>>(nomControleur);
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
