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
    public class GameDAO : IGameDAO
    {
        private readonly PlayersApiContext _context;
        private readonly IMapper _mapper;

        public GameDAO(PlayersApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Guid CreateGame(DomainLayer.Entities.Game entityGame)
        {
            try
            {
                var modelGame = _mapper.Map<Models.Game>(entityGame);
                _context.Games.Add(modelGame);
                _context.SaveChanges();
                return entityGame.Id;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error creating game: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error creating game: {ex.Message}");
            }
        }

        public void DeleteGame(Guid id)
        {
            var game = _context.Games.Find(id);

            if (game == null)
                throw new InvalidOperationException($"Game with Id {id} not found.");

            _context.Games.Remove(game);
            var affectedRows = _context.SaveChanges();

            if (affectedRows != 1)
            {
                throw new InvalidOperationException($"Expected 1 row to be affected, but {affectedRows} rows were affected.");
            }
        }

        public List<DomainLayer.Entities.Game> GetAllGames()
        {
            try
            {
                var gamesEF = _context.Games.ToList();

                var gamesResult = _mapper.Map<List<DomainLayer.Entities.Game>>(gamesEF);
                return gamesResult;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving games: {ex.Message}");
            }
        }
    }
}

