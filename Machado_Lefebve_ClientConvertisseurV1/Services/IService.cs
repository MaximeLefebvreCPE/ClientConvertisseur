using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machado_Lefebvre_WsConvertisseur.Models;

namespace Machado_Lefebve_ClientConvertisseurV1.Services
{
    internal interface IService
    {
        Task<List<Devise>> GetDevisesAsync(string nomControleur);
    }
}
