using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.ValueObjects;
using InfraestructureLayer.Interfaces;
using InfraestructureLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace InfraestructureLayer
{
    public class VideoGameDAO : IVideoGameDAO
    {
        private readonly PlayersApiContext _context;
        private readonly IMapper _mapper;

        public VideoGameDAO(PlayersApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Guid CreateVideoGame(DomainLayer.Entities.VideoGame entityVideoGame)
        {
            try
            {
                var videoGamesEF = _context.VideoGames.ToList();
                bool existingVideoGame = videoGamesEF.Any(v => v.VideoGameName.Equals(entityVideoGame.Name));

                if (existingVideoGame)
                    throw new InvalidOperationException($"The video game name entered already exists.");

                var modelVideoGame = _mapper.Map<Models.VideoGame>(entityVideoGame);
                _context.VideoGames.Add(modelVideoGame);
                _context.SaveChanges();
                return entityVideoGame.Id;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error creating video game: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error creating video game: {ex.Message}");
            }
        }

        public void DeleteVideoGame(Guid id)
        {
            var videoGame = _context.VideoGames.Find(id);

            if (videoGame == null)
                throw new InvalidOperationException($"Video game with Id {id} not found.");

            var usingVideoGame = _context.Games.Any(g => g.VideoGame.VideoGameId == id);

            if (usingVideoGame)
                throw new InvalidOperationException($"the game you want to delete is associated with a game");

            _context.VideoGames.Remove(videoGame);
            var affectedRows = _context.SaveChanges();

            if (affectedRows != 1)
            {
                throw new InvalidOperationException($"Expected 1 row to be affected, but {affectedRows} rows were affected.");
            }
        }

        public List<DomainLayer.Entities.VideoGame> GetAllVideoGames()
        {
            try
            {
                var videoGamesEF = _context.VideoGames.ToList();

                var videoGamesResult = _mapper.Map<List<DomainLayer.Entities.VideoGame>>(videoGamesEF);
                return videoGamesResult;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving video games: {ex.Message}");
            }
        }
    }
}

