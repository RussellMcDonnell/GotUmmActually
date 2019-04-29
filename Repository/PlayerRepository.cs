using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Repository
{
    public interface IPlayerRepository
    {
        void AddPlayer(string name, int score);
        List<Player> GetAllPlayers();
    }
    public class PlayerRepository : IPlayerRepository
    {
        public PlayerRepository()
        {
            Players = new ConcurrentDictionary<Guid, Player>();
        }
        private ConcurrentDictionary<Guid, Player> Players { get; set; }

        public void AddPlayer(string playerName, int score)
        {
            var playerId = Guid.NewGuid();
            var player = new Player
            {
                Id = playerId,
                Name = playerName,
                Score = score
            };

            Players.AddOrUpdate(playerId, player, (_, __) => player);
        }

        public List<Player> GetAllPlayers()
        {
            return Players.Values.ToList();
        }
    }
}
