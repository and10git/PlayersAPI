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
    public class PlayerDAO : IPlayerDAO
    {
        private readonly PlayersApiContext _context;
        private readonly IMapper _mapper;

        public PlayerDAO(PlayersApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DomainLayer.Entities.Player> GetAllPlayers()
        {
            try
            {
                var playersEF = _context.Players.ToList();

                var playesrResult = _mapper.Map<List<DomainLayer.Entities.Player>>(playersEF);
                return playesrResult;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving players: {ex.Message}");
            }
        }

        public DomainLayer.Entities.Player GetPlayerById(Guid id)
        {
            try
            {
                var player = _context.Players.Find(id);

                if (player == null)
                {
                    throw new InvalidOperationException($"Player with Id {id} not found.");
                }

                var playesrResult = _mapper.Map<DomainLayer.Entities.Player>(player);
                return playesrResult;
            }
            catch (Exception ex)
            {
                throw new ($"Error retrieving player: {ex.Message}");
            }
        }

        public Guid CreatePlayer(DomainLayer.Entities.Player entityPlayer)
        {      
            try
            {
                var existingEmail = GetAllPlayers().Any(p => p.Email.Equals(entityPlayer.Email));

                if(existingEmail)
                    throw new InvalidOperationException($"The email entered already exists.");

                var modelPlayer = _mapper.Map<Models.Player>(entityPlayer);
                _context.Players.Add(modelPlayer);
                _context.SaveChanges();
                return entityPlayer.Id;
            }
            catch (DbUpdateException ex)
            {                
                throw new DbUpdateException($"Error creating player: {ex.Message}");
            }
            catch (Exception ex)
            {               
                throw new Exception($"Unexpected error creating player: {ex.Message}");
            }
        }

        public void UpdatePlayer(Guid id, string nickName)
        {
            try
            {
                var player = _context.Players.Find(id);

                if (player == null)
                    throw new InvalidOperationException($"Player with Id {id} not found.");

                player.PlayerNickName = nickName;
                _context.Players.Update(player);
                var affectedRows = _context.SaveChanges();

                if (affectedRows != 1)
                {                   
                    throw new InvalidOperationException($"Expected 1 row to be affected, but {affectedRows} rows were affected.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error updating player: {ex.Message}"); 
            }
        }

        public void DeletePlayer(Guid playerId)
        {
            var player = _context.Players.Find(playerId);

            if (player == null)
                throw new InvalidOperationException($"Player with Id {playerId} not found.");

            _context.Players.Remove(player);
            var affectedRows = _context.SaveChanges();

            if (affectedRows != 1)
            {
                throw new InvalidOperationException($"Expected 1 row to be affected, but {affectedRows} rows were affected.");
            }
        
        }
    }
}

