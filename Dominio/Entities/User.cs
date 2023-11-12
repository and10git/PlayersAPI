using DomainLayer.ValueObjects;

namespace DomainLayer.Entities
{
    public class User
    {
        public Guid Id { get; init; }
        public string Name { get; private set; }
        public string Password { get; private set; }
        public User()
        {

        }
        public User(Guid id, string name, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
        }
    }
}