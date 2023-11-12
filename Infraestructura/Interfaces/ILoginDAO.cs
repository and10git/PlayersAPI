using DomainLayer.Entities;
using DomainLayer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraestructureLayer.Interfaces
{
    public interface ILoginDAO
    {
        void CreateUser(DomainLayer.Entities.User user);
        bool Exists(string username, string password);
    }
}
