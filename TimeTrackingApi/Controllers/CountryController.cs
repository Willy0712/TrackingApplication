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
  public class CountryController : ControllerBase
  {
    private readonly trackingcontext _context;

    public CountryController(trackingcontext context)
    {
      _context = context;
    }

    // GET: api/Country
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CountryDTO>>> GetCountry()
    {

      var claims = (User.Identity as ClaimsIdentity).Claims;
      var currentLoggedInUser = _context.Users.Find(long.Parse(claims.FirstOrDefault(c => c.Type == "UserId").Value));

      var id = currentLoggedInUser.id;


      var query = _context.Country.AsQueryable();


      return await query.Include(t => t.Trackings).Select(item => CountryMappers.countryToDTO(item)).ToListAsync();


    }

    // GET: api/Trackings/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CountryDTO>> GetCountry(long id)
    {
      var country = await _context.Country.Include(s => s.Trackings).FirstOrDefaultAsync(item => item.id == id);

      //  var query =  _context.Tracking.AsQueryable();

      if (country == null)
      {
        return NotFound();
      }

      // query = query.Where(item => item.id == id);

      return CountryMappers.countryToDTO(country);

    }

    //   return await query.Include(s => s.SubActivities)
    //   .Select(item => TrackingMappers.trackinToDTO (item)).ToListAsync();

    //   return query.Select(item => TrackingMappers.trackinToDTO(item));




    // PUT: api/Trackings/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCountry(long id, CountryDTO countryDTO)
    {
      if (id != countryDTO.id)
      {
        return BadRequest();
      }

      // _context.Entry(tracking).State = EntityState.Modified;

      //   var trackingItem = await _context.Tracking.Include(s => s.SubActivities) FindAsync(id);

      var countryItem = await _context.Country.Include(t => t.Trackings).FirstOrDefaultAsync(item => item.id == id);

      if (countryItem == null)
      {
        return NotFound();
      }

      countryItem.name = countryDTO.name;
      countryItem.code = countryDTO.code;
      if (countryDTO.Trackings != null)
        // {
        //   countryItem.Trackings = countryDTO.Trackings.Count() > 0 ? countryDTO.Trackings.Select(x => CountryMappers.DTOtoCountry(x)).ToList() : new List<tracking>();
        // }

        try
        {
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!countryExists(id))
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


    public async Task<ActionResult<CountryDTO>> AddCountryDTO(CountryDTO countryDTO)
    {

      var claims = (User.Identity as ClaimsIdentity).Claims;
      var currentLoggedInUser = _context.Users.Find(long.Parse(claims.FirstOrDefault(c => c.Type == "UserId").Value));

      var idLong = long.Parse(claims.FirstOrDefault(c => c.Type == "UserId").Value);



      var country = CountryMappers.DTOtoCountry(countryDTO);



      // var trackingItem = await _context.Tracking.Include(s => s.SubActivities).FirstOrDefaultAsync(item => item.id == id);


      _context.Country.Add(country);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetCountry), new { id = countryDTO.id }, CountryMappers.countryToDTO(country));



    }

    // DELETE: api/Trackings/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountry(long id)
    {
      var country = await _context.Country.FindAsync(id);
      if (country == null)
      {
        return NotFound();
      }

      _context.Country.Remove(country);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool countryExists(long id)
    {
      return _context.Country.Any(e => e.id == id);
    }

    private bool CountryExists(long id)
    {
      return _context.Country.Any(e => e.id == id);
    }

  }
}
