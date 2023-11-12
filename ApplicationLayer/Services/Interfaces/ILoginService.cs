using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Interfaces
{
    public interface ILoginService
    {
        string GetToken(string username, string encriptedPassword);
        string EncodePassword(string password);
        bool Authenticate(string user, string password);
        void CreateUser(string usuario, string encriptedPassword);
    }
}
