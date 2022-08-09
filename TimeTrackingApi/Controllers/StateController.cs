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
  public class StateController : ControllerBase
  {
    private readonly trackingcontext _context;

    public StateController(trackingcontext context)
    {
      _context = context;
    }

    // GET: api/Country
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StateDTO>>> GetCountry()
    {

      var claims = (User.Identity as ClaimsIdentity).Claims;
      var currentLoggedInUser = _context.Users.Find(long.Parse(claims.FirstOrDefault(c => c.Type == "UserId").Value));

      var id = currentLoggedInUser.id;


      var query = _context.State.AsQueryable();


      return await query
      .Include(c => c.Country)
      // .ThenInclude(t => t.Trackings)
      .Select(item => StateMappers.stateToDTO(item))

      .ToListAsync();


    }

    // GET: api/Trackings/5
    [HttpGet("{id}")]
    public async Task<ActionResult<StateDTO>> GetState(long id)
    {
      var state = await _context.State.Include(s => s.Trackings).FirstOrDefaultAsync(item => item.id == id);

      //  var query =  _context.Tracking.AsQueryable();

      if (state == null)
      {
        return NotFound();
      }

      // query = query.Where(item => item.id == id);

      return StateMappers.stateToDTO(state);

    }

    //   return await query.Include(s => s.SubActivities)
    //   .Select(item => TrackingMappers.trackinToDTO (item)).ToListAsync();

    //   return query.Select(item => TrackingMappers.trackinToDTO(item));




    // PUT: api/Trackings/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateState(long id, StateDTO stateDTO)
    {
      if (id != stateDTO.id)
      {
        return BadRequest();
      }

      // _context.Entry(tracking).State = EntityState.Modified;

      //   var trackingItem = await _context.Tracking.Include(s => s.SubActivities) FindAsync(id);

      var stateItem = await _context.State.Include(t => t.Trackings).FirstOrDefaultAsync(item => item.id == id);

      if (stateItem == null)
      {
        return NotFound();
      }

      stateItem.name = stateDTO.name;
      stateItem.code = stateDTO.code;
      if (stateDTO.Trackings != null)
        // {
        //   countryItem.Trackings = countryDTO.Trackings.Count() > 0 ? countryDTO.Trackings.Select(x => CountryMappers.DTOtoCountry(x)).ToList() : new List<tracking>();
        // }

        try
        {
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!stateExists(id))
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


    public async Task<ActionResult<StateDTO>> AddStateDTO(StateDTO stateDTO)
    {

      var claims = (User.Identity as ClaimsIdentity).Claims;
      var currentLoggedInUser = _context.Users.Find(long.Parse(claims.FirstOrDefault(c => c.Type == "UserId").Value));

      var idLong = long.Parse(claims.FirstOrDefault(c => c.Type == "UserId").Value);



      var state = StateMappers.DTOtoState(stateDTO);



      // var trackingItem = await _context.Tracking.Include(s => s.SubActivities).FirstOrDefaultAsync(item => item.id == id);


      _context.State.Add(state);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetState), new { id = stateDTO.id }, StateMappers.stateToDTO(state));



    }

    // DELETE: api/Trackings/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteState(long id)
    {
      var state = await _context.State.FindAsync(id);
      if (state == null)
      {
        return NotFound();
      }

      _context.State.Remove(state);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool stateExists(long id)
    {
      return _context.State.Any(e => e.id == id);
    }

    private bool StateExists(long id)
    {
      return _context.State.Any(e => e.id == id);
    }

  }
}
