
namespace DomainLayer.Entities
{
    public class VideoGame
    {
        public Guid Id { get; init; }
        public string Name{ get; private set; }
        public string Genre{ get; private set; }
        public VideoGame()
        {

        }
        public VideoGame(Guid id, string name, string genre)
        {
            this.Id = id;
            this.Name = name; 
            this.Genre = genre;
        }
    }
}