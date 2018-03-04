using System;
using System.Threading.Tasks;
using Zsebi2.Models;

namespace Zsebi2.Services
{
    public interface ITeamService
    {
        Task<TeamViewModel> GetTeamViewModel();
    }
}
