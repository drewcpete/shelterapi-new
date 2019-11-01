using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AnimalShelterApi.Models;
using Microsoft.EntityFrameworkCore;


namespace AnimalShelterApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private AnimalShelterApiContext _db;

    public AnimalsController(AnimalShelterApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Animal>> Get(string species, string gender, string name, int age)
    {
      var query = _db.Animals.AsQueryable();


    if (species != null)
    {
    query = query.Where(entry => entry.Species == species);
    }

    if (gender != null)
    {
    query = query.Where(entry => entry.Gender == gender);
    }

    if (name != null)
    {
    query = query.Where(entry => entry.Name == name);
    }
    if (age != 0)
    {
        query = query.Where(entry => entry.Age == age);
    }

    return query.ToList();
    }

    [HttpPost]
    public void Post([FromBody] Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
    }

    [HttpGet("{id}")]
    public ActionResult<Animal> Get(int id)
    {
        return _db.Animals.FirstOrDefault(entry => entry.ID == id);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Animal animal)
    {
        animal.ID = id;
        _db.Entry(animal).State = EntityState.Modified;
        _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var animalToDelete = _db.Animals.FirstOrDefault(entry => entry.ID == id);
      _db.Animals.Remove(animalToDelete);
      _db.SaveChanges();
    }
  }
}