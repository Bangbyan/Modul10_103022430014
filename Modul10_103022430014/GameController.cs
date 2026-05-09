using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace Modul10_103022430014
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private static List<Game> dataGame = new List<Game>
        {
            new Game { id = 1, Nama = "Valorant", Developer = "Riot Games", TahunRilis = 2020, Genre = "FPS", Rating = 8.5, Platform =  ["PC"], Mode = ["Multiplayer"], IsOnline = true, Harga = 0},
            new Game { id = 2, Nama = "GTA V", Developer =  "Rockstar Games", TahunRilis = 2013, Genre = "Open World", Rating =  9.5, Platform =  ["PC”, “PS4”, “PS5”, “Xbox"], Mode = ["Singleplayer”,“Multiplayer"], IsOnline = true, 
                Harga = 300000},
            new Game { id = 3, Nama = "The Witcher 3", Developer = "CD Projekt Red", TahunRilis = 2015, Genre = "RPG", Rating = 9.7, Platform =  ["PC”, “PS4”, “PS5”, “Xbox”, “Switch"], 
                Mode =  ["Singleplayer"], IsOnline =  false, Harga = 250000}
        };

        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get()
        {
            return Ok(dataGame); 
        }
        [HttpGet("{id}")]
        public ActionResult<Game> Get(int id)
        {
            if (id < 0 || id >= dataGame.Count) return NotFound();
            return dataGame[id];
        }
        [HttpPost]
        public IActionResult Post(Game newGame)
        {
            dataGame.Add(newGame);
            return Ok(newGame);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= dataGame.Count) return NotFound();
            dataGame.RemoveAt(id);
            return Ok();
        }
    }
}
