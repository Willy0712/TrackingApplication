#nullable disable

using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeTrackingApi.DTOs;
using TimeTrackingApi.Mappers;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CityController : ControllerBase
  {
    private readonly trackingcontext _context;

    public CityController(trackingcontext context)
    {
      _context = context;
    }

    // GET: api/Country
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CityDTO>>> GetCity()
    {

      var claims = (User.Identity as ClaimsIdentity).Claims;
      var currentLoggedInUser = _context.Users.Find(long.Parse(claims.FirstOrDefault(c => c.Type == "UserId").Value));

      var id = currentLoggedInUser.id;


      var query = _context.City.AsQueryable();


      return await query
      .Include(c => c.State)
      // .ThenInclude(t => t.Trackings)
      .Select(item => CityMappers.ctiyToDTO(item))

      .ToListAsync();


    }

    // GET: api/Trackings/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CityDTO>> GetCity(long id)
    {
      var city = await _context.City.Include(s => s.Trackings).FirstOrDefaultAsync(item => item.id == id);

      //  var query =  _context.Tracking.AsQueryable();

      if (city == null)
      {
        return NotFound();
      }

      // query = query.Where(item => item.id == id);

      return CityMappers.ctiyToDTO(city);

    }

    //   return await query.Include(s => s.SubActivities)
    //   .Select(item => TrackingMappers.trackinToDTO (item)).ToListAsync();

    //   return query.Select(item => TrackingMappers.trackinToDTO(item));




    // PUT: api/Trackings/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCity(long id, CityDTO cityDTO)
    {
      if (id != cityDTO.id)
      {
        return BadRequest();
      }

      // _context.Entry(tracking).State = EntityState.Modified;

      //   var trackingItem = await _context.Tracking.Include(s => s.SubActivities) FindAsync(id);

      var cityItem = await _context.City.Include(t => t.Trackings).FirstOrDefaultAsync(item => item.id == id);

      if (cityItem == null)
      {
        return NotFound();
      }

      cityItem.name = cityDTO.name;
      cityItem.code = cityDTO.code;
      if (cityDTO.Trackings != null)
        // {
        //   countryItem.Trackings = countryDTO.Trackings.Count() > 0 ? countryDTO.Trackings.Select(x => CountryMappers.DTOtoCountry(x)).ToList() : new List<tracking>();
        // }

        try
        {
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!cityExists(id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }

      return NoContent();
    }


    // POST: api/Trackings
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<StateDTO>> AddSCityDTO(CityDTO cityDTO)
    {

      var claims = (User.Identity as ClaimsIdentity).Claims;
      var currentLoggedInUser = _context.Users.Find(long.Parse(claims.FirstOrDefault(c => c.Type == "UserId").Value));

      var idLong = long.Parse(claims.FirstOrDefault(c => c.Type == "UserId").Value);



      var city = CityMappers.DTOtoCity(cityDTO);



      // var trackingItem = await _context.Tracking.Include(s => s.SubActivities).FirstOrDefaultAsync(item => item.id == id);


      _context.City.Add(city);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetCity), new { id = cityDTO.id }, CityMappers.ctiyToDTO(city));



    }

    // DELETE: api/Trackings/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCity(long id)
    {
      var city = await _context.City.FindAsync(id);
      if (city == null)
      {
        return NotFound();
      }

      _context.City.Remove(city);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool cityExists(long id)
    {
      return _context.City.Any(e => e.id == id);
    }

    private bool CityExists(long id)
    {
      return _context.City.Any(e => e.id == id);
    }

  }
}
