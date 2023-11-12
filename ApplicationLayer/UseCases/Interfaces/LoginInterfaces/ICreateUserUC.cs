using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.UseCases.Interfaces.LoginInterfaces
{
    public interface ICreateUserUC
    {
        void CreateUser(string usuario, string password);
    }
}
