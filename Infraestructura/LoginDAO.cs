using AutoMapper;
using InfraestructureLayer.Interfaces;
using InfraestructureLayer.Models;

namespace InfraestructureLayer
{
    public class LoginDAO : ILoginDAO
    {
        private readonly PlayersApiContext _context;
        private readonly IMapper _mapper;

        public LoginDAO(PlayersApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Exists(string username, string password)
        {
            try
            {
                var user = _context.User.FirstOrDefault(u => u.UserName.Equals(username) && u.UserPassword.Equals(password));

                return user != null;
            }

            catch (Exception ex)
            {
                throw new Exception($"Invalid credentials: {ex.Message}");
            }

        }

        public void CreateUser(DomainLayer.Entities.User user)
        {
            try
            {
                if (Exists(user.Name, user.Password))
                    throw new InvalidOperationException($"The user entered already exists.");


                var modelUser = _mapper.Map<Models.User>(user);
                _context.User.Add(modelUser);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error to create user: {ex.Message}");
            }
        }

    }
}

