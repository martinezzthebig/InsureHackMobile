using InsurHackMobile.Models;
using System.Threading.Tasks;

namespace InsurHackMobile.Services
{
    public interface IUserService
    {
        Task<User> SignInUser(string email, string password);
        Task SingUpUser(User user);
    }
}
