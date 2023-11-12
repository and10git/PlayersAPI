using System;
using System.Collections.Generic;

namespace InfraestructureLayer.Models;

public partial class Game
{
    public Guid GameId { get; set; }

    public Guid VideoGameId { get; set; }

    public Guid PlayerId { get; set; }

    public double? GamePoints { get; set; }

    public double? GameTimePlayed { get; set; }

    public virtual Player Player { get; set; } = null!;

    public virtual VideoGame VideoGame { get; set; } = null!;
}
