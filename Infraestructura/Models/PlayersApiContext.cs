using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InfraestructureLayer.Models;

public partial class PlayersApiContext : DbContext
{
    private readonly IConfiguration _configuration;
    public PlayersApiContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public PlayersApiContext(DbContextOptions<PlayersApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<VideoGame> VideoGames { get; set; }

    public virtual DbSet<User> User{ get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("LocalDB"));   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("PK_Game_1");

            entity.ToTable("Game");

            entity.Property(e => e.GameId).ValueGeneratedNever();

            entity.HasOne(d => d.Player).WithMany(p => p.Games)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Game_Player");

            entity.HasOne(d => d.VideoGame).WithMany(p => p.Games)
                .HasForeignKey(d => d.VideoGameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Game_VideoGame");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.ToTable("Player");

            entity.Property(e => e.PlayerId).ValueGeneratedNever();
            entity.Property(e => e.PlayerEmail).HasMaxLength(50);
            entity.Property(e => e.PlayerName).HasMaxLength(100);
            entity.Property(e => e.PlayerNickName).HasMaxLength(100);
        });

        modelBuilder.Entity<VideoGame>(entity =>
        {
            entity.HasKey(e => e.VideoGameId).HasName("PK_Game");

            entity.ToTable("VideoGame");

            entity.Property(e => e.VideoGameId).ValueGeneratedNever();
            entity.Property(e => e.VideoGameGenre).HasMaxLength(50);
            entity.Property(e => e.VideoGameName).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_User");

            entity.ToTable("User");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.UserPassword).HasMaxLength(255);            
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
