using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.UseCases.Interfaces.LoginInterfaces
{
    public interface ILoginUC
    {
        string GetToken(string usuario, string password);
        bool Authenticate(string usuario, string password);

    }
}
