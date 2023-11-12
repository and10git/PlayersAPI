using DomainLayer.ValueObjects;

namespace DomainLayer.Entities
{
    public class Player
    {
        public Guid Id { get; init; }
        public string Name { get; private set; }
        public string NickName { get; private set; }
        public EmailVO Email { get; private init; }
        public Player()
        {

        }
        public Player(Guid id, string name, string nickName, string email)
        {
            this.Id = id;
            this.Name = name;
            this.NickName = nickName;
            this.Email = new EmailVO(email);
        }
    }
}