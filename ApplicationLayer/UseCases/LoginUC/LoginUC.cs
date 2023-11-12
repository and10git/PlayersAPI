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
    public class LoginUC : ILoginUC
    {
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;
        public LoginUC()
        {

        }
        public LoginUC(ILoginService loginService, IMapper mapper)
        {
            _loginService = loginService;
            _mapper = mapper;
        }

        public bool Authenticate(string usuario, string password)
        {
            var encriptedPassword = _loginService.EncodePassword(password);
            bool existsUser = _loginService.Authenticate(usuario, encriptedPassword);

            return existsUser;
        }

        public string GetToken(string user, string password) 
        {
            var encriptedPassword = _loginService.EncodePassword(password);
            var token = _loginService.GetToken(user, encriptedPassword);

            return token;
        }
    }
}
