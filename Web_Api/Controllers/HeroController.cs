using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Web_Api.Model;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private static List<Hero> Heroes = new List<Hero>
        {
            new Hero { Id = 1, Name = "aeojfqef", FirstName = "qjdnqe", LastName = "qwjfqw", Place = "qeqwdqd"},
            new Hero { Id = 2, Name = "qwdd", FirstName = "wqd", LastName = "qwd", Place = "qef"}
        };

        [HttpGet]
        public async Task<ActionResult<List<Hero>>> GetHeroes()
        {
            return Ok(Heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHeroById(int id)
        {
            Hero? hero = Heroes.Find(x => x.Id == id);
            if (hero == null)
                return NotFound("Not found! Please try another Id");
            return Ok(Heroes);
        }

        [HttpPost]

        public async Task<ActionResult<List<Hero>>> AddHeroes(Hero hero)
        {
            Heroes.Add(hero);
            return Ok(Heroes);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Hero>>> UpdateHero(int id, Hero newHero)
        {
            Hero? hero = Heroes.Find(x => x.Id == id);
            if (hero == null)
                return NotFound("Not found! Please try another Id");

            hero.Name = newHero.Name;
            hero.FirstName = newHero.FirstName;
            hero.LastName = newHero.LastName;
            hero.Place = newHero.Place;
            return Ok(Heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Hero>>> DeleteHero(int id)
        {
            Hero? hero = Heroes.Find(x => x.Id == id);
            if (hero == null)
                return NotFound("Not found! Please try another Id");
            Heroes.Remove(hero);
            return Ok(Heroes);
        }

    }
}
