using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace GOT_Umm_Actually.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        private ConcurrentDictionary<Guid, Player> Scores { get; set; }

        [HttpGet]
        public List<Player> GetPlayers()
        {
            return _playerRepository.GetAllPlayers().OrderByDescending(x => x.Score).ToList();
        }

        [HttpPost]
        public void AddPlayer([FromBody]Player player)
        {
            _playerRepository.AddPlayer(player.Name, player.Score);
        }
    }
}
