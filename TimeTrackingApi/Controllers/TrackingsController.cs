#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeTrackingApi;
using TimeTrackingApi.DTOs;
using TimeTrackingApi.Mappers;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class TrackingsController : ControllerBase
  {
    private readonly trackingcontext _context;

    public TrackingsController(trackingcontext context)
    {
      _context = context;
    }

    // GET: api/Trackings
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrackingDTO>>> GetTracking(long? hours)
    {

      var claims = (User.Identity as ClaimsIdentity).Claims;
      var currentLoggedInUser = _context.Users.Find(long.Parse(claims.FirstOrDefault(c => c.Type == "UserId").Value));

      var id = currentLoggedInUser.id;


      var query = _context.Tracking.AsQueryable();
      if (hours.HasValue)
      {
        query = query.Where(item => item.numberOfHours <= hours.Value && item.Parent.id == currentLoggedInUser.id).OrderByDescending(data => data.numberOfHours);
      }

      query = query.Where(item => item.Parent.id == currentLoggedInUser.id);

      return await query.Include(s => s.SubActivities).Select(item => TrackingMappers.trackinToDTO(item)).ToListAsync();


    }

    // GET: api/Trackings/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TrackingDTO>> Gettracking(long id)
    {
      var tracking = await _context.Tracking.Include(s => s.SubActivities).FirstOrDefaultAsync(item => item.id == id);

      //  var query =  _context.Tracking.AsQueryable();

      if (tracking == null)
      {
        return NotFound();
      }

      // query = query.Where(item => item.id == id);

      return TrackingMappers.trackinToDTO(tracking);

    }

    //   return await query.Include(s => s.SubActivities)
    //   .Select(item => TrackingMappers.trackinToDTO (item)).ToListAsync();

    //   return query.Select(item => TrackingMappers.trackinToDTO(item));




    // PUT: api/Trackings/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTracking(long id, TrackingDTO trackingDTO)
    {
      if (id != trackingDTO.id)
      {
        return BadRequest();
      }

      // _context.Entry(tracking).State = EntityState.Modified;

      //   var trackingItem = await _context.Tracking.Include(s => s.SubActivities) FindAsync(id);

      var trackingItem = await _context.Tracking.Include(s => s.SubActivities).FirstOrDefaultAsync(item => item.id == id);

      if (trackingItem == null)
      {
        return NotFound();
      }

      trackingItem.name = trackingDTO.name;
      trackingItem.description = trackingDTO.description;
      trackingItem.date = trackingDTO.date;
      trackingItem.numberOfHours = trackingDTO.numberOfHours;
      if (trackingDTO.subActivities != null)
      {
        trackingItem.SubActivities = trackingDTO.subActivities.Count() > 0 ? trackingDTO.subActivities.Select(x => SubActivityMappers.DTOtoSubActivity(x)).ToList() : new List<SubActivity>();
      }

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!trackingExists(id))
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


    public async Task<ActionResult<TrackingDTO>> AddTrackigDTO(TrackingDTO trackingDTO)
    {

      var claims = (User.Identity as ClaimsIdentity).Claims;
      var currentLoggedInUser = _context.Users.Find(long.Parse(claims.FirstOrDefault(c => c.Type == "UserId").Value));

      var idLong = long.Parse(claims.FirstOrDefault(c => c.Type == "UserId").Value);



      var tracking = TrackingMappers.DTOtoTracking(trackingDTO);

      tracking.Parent = currentLoggedInUser;

      // var trackingItem = await _context.Tracking.Include(s => s.SubActivities).FirstOrDefaultAsync(item => item.id == id);


      _context.Tracking.Add(tracking);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(Gettracking), new { id = trackingDTO.id }, TrackingMappers.trackinToDTO(tracking));



    }

    // DELETE: api/Trackings/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletetracking(long id)
    {
      var tracking = await _context.Tracking.FindAsync(id);
      if (tracking == null)
      {
        return NotFound();
      }

      _context.Tracking.Remove(tracking);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool trackingExists(long id)
    {
      return _context.Tracking.Any(e => e.id == id);
    }

    private bool TrackingExists(long id)
    {
      return _context.Tracking.Any(e => e.id == id);
    }


    [HttpGet("{id}")]
    [Route("filter")]
    public async Task<ActionResult<IEnumerable<TrackingCountryDTO>>> FilteredByCountryAsc(string country)
    {

      var claims = (User.Identity as ClaimsIdentity).Claims;
      var currentLoggedInUser = _context.Users.Find(long.Parse(claims.FirstOrDefault(c => c.Type == "UserId").Value));
      var id = currentLoggedInUser.id;
      var query = _context.Tracking.AsQueryable();

      if (_context.Tracking == null)
      {
        return NotFound();
      }

      return await _context.Tracking

      .Join(
            _context.Country,
            tracking => tracking.Countryid,
            country => country.id,
            (tracking, country) => new TrackingCountryDTO
            {
              userId = tracking.Parent.id,
              name = tracking.name,
              description = tracking.description,
              date = tracking.date,
              numberOfHours = tracking.numberOfHours,
              CountyName = country.name,

            }
      )
      .Where(entry => entry.userId == id && entry.CountyName == country)
      .OrderByDescending(entry => entry.numberOfHours)
      .ToListAsync();
      // }


    }


    [HttpGet("{city}")]
    [Route("cityfilter")]
    public async Task<ActionResult<IEnumerable<TrackingCountryStateCityDTO>>> FilteredByCountryStateCityAsc(string searchCity)
    {

      var claims = (User.Identity as ClaimsIdentity).Claims;
      var currentLoggedInUser = _context.Users.Find(long.Parse(claims.FirstOrDefault(c => c.Type == "UserId").Value));
      var id = currentLoggedInUser.id;
      var query = _context.Tracking.AsQueryable();

      if (_context.Tracking == null)
      {
        return NotFound();
      }

      return await _context.Tracking
      .Join(
        _context.City,
        tracking => tracking.Cityid,
        city => city.id,
        (tracking, city) => new TrackingCountryStateCityDTO
        {
          userId = tracking.Parent.id,
          name = tracking.name,
          description = tracking.description,
          date = tracking.date,
          numberOfHours = tracking.numberOfHours,
          CityName = city.name,
        }

      )
      .Where(entry => entry.userId == id && entry.CityName == searchCity)
      .OrderBy(entry => entry.numberOfHours)

      // .OrderByDescending(desc => desc.numberOfHours)
      .ToListAsync();
      // }


    }


    [HttpGet("{state}")]
    [Route("statefilter")]
    public async Task<ActionResult<IEnumerable<TrackingStateDTO>>> FilteredByStateStateCityAsc(string searchState, DateTime startDateTime, DateTime endDateTime)
    {

      var claims = (User.Identity as ClaimsIdentity).Claims;
      var currentLoggedInUser = _context.Users.Find(long.Parse(claims.FirstOrDefault(c => c.Type == "UserId").Value));
      var id = currentLoggedInUser.id;
      var query = _context.Tracking.AsQueryable();

      if (_context.Tracking == null)
      {
        return NotFound();
      }

      return await _context.Tracking
      .Join(
        _context.State,
        tracking => tracking.Stateid,
        state => state.id,
        (tracking, state) => new TrackingStateDTO
        {
          userId = tracking.Parent.id,
          name = tracking.name,
          description = tracking.description,
          date = tracking.date,
          numberOfHours = tracking.numberOfHours,
          StateName = state.name,
        }

      )
      .Where(entry => entry.userId == id && entry.StateName == searchState && entry.date >= startDateTime && entry.date <= endDateTime)
      .OrderBy(entry => entry.numberOfHours)

      // .OrderByDescending(desc => desc.numberOfHours)
      .ToListAsync();
      // }


    }
  }
}
