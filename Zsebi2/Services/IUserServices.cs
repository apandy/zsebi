using System.Threading.Tasks;
using Zsebi2.Models;

namespace Zsebi2.Services
{
    public interface IUserServices
    {
        Task<UserModel> GetAdminUser();
        Task SaveAdminUser(string email, string password);
    }
}