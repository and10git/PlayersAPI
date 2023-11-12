using ApplicationLayer.Services.Interfaces;
using ApplicationLayer.UseCases.Interfaces.LoginInterfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.UseCases.LoginUC
{
    public class CreateUserUC : ICreateUserUC
    {
        private readonly ILoginService _loginService;
        public CreateUserUC()
        {

        }
        public CreateUserUC(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public void CreateUser(string usuario, string password)
        {
            var encriptedPassword = _loginService.EncodePassword(password);
            _loginService.CreateUser(usuario, encriptedPassword);
        }      
    }
}
