using System.ComponentModel;
using System.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Database;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        // GET: api/Songs
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Song> Get()
        {
            return ReadSong.GetAll();
        }

        // GET: api/Songs/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Song Get(int id)
        {
            return ReadSong.GetOne(id);
        }

        // POST: api/Songs
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Song value)
        {
            Song newSong = new Song(value.SongTitle);
            CreateSong.Create(newSong);
        }

        // PUT: api/Songs/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id)
        {
            FavoriteSong favoriteSong = new FavoriteSong();
            favoriteSong.Favorite(id);
        }

        // DELETE: api/Songs/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DeleteSong.Delete(id);
        }
    }
}
