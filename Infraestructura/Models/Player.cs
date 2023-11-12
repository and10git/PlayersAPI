using System;
using System.Collections.Generic;

namespace InfraestructureLayer.Models;

public partial class Player
{
    public Guid PlayerId { get; set; }

    public string? PlayerName { get; set; }

    public string? PlayerNickName { get; set; }

    public string? PlayerEmail { get; set; }

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
