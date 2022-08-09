#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
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
  public class SubActivityController : ControllerBase
  {
    private readonly trackingcontext _context;

    public SubActivityController(trackingcontext context)
    {
      _context = context;
    }

    // GET: api/SubActivity
    [HttpGet(template: "{trackingId}")]
    public async Task<ActionResult<IEnumerable<SubActivityDTO>>> GetSubActivity(long trackingId)
    {
      return await _context.SubActivity
      .Where(item => item.Parent.id == trackingId)
      .Select(item => SubActivityMappers.SubActivityToDTO(item))
      .ToListAsync();

    }

    // GET: api/subactivity/5
    //     [HttpGet("{id}")]
    //     public async Task<ActionResult<SubActivityDTO>> Gettracking(long id)
    //     {
    //         var tracking = await _context.SubActivity.FindAsync(id);

    //         if (tracking == null)
    //         {
    //             return NotFound();
    //         }

    //   return SubActivityMappers.SubActivityToDTO(tracking);
    // }



    // PUT: api/Subactivity/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSubactivity(long id, SubActivityDTO subActivityDTO)
    {
      if (id != subActivityDTO.id)
      {
        return BadRequest();
      }


      // _context.Entry(tracking).State = EntityState.Modified;

      var subActivityItem = await _context.SubActivity.FindAsync(id);
      if (subActivityItem == null)
      {
        return NotFound();
      }

      subActivityItem.description = subActivityDTO.description;
      subActivityItem.numberOfHours = subActivityDTO.numberOfHours;
      subActivityItem.Dificulty = subActivityDTO.Dificulty;
      //   trackingItem.date = trackingDTO.date        
      //   trackingItem.numberOfHours = trackingDTO.numberOfHours;        


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

    // // POST: api/SubActivity
    // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // [HttpPost]
    // public async Task<ActionResult<TrackingDTO>> AddTrackigDTO(TrackingDTO trackingDTO)
    // {

    //   var tracking = new tracking
    //   {
    //     name = trackingDTO.name,
    //     description = trackingDTO.description,
    //     date = trackingDTO.date,
    //     numberOfHours = trackingDTO.numberOfHours
    //   };


    //   _context.Tracking.Add(tracking);
    //   await _context.SaveChangesAsync();

    //         return CreatedAtAction(nameof(Gettracking), new { id = trackingDTO.id }, trackinToDTO(tracking));
    //     }

    // DELETE: api/Trackings/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletetracking(long id)
    {
      var subActivity = await _context.SubActivity.FindAsync(id);
      if (subActivity == null)
      {
        return NotFound();
      }

      _context.SubActivity.Remove(subActivity);
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

    private static SubActivityDTO subActivityToDTO(SubActivity tracking) =>
      new SubActivityDTO
      {
        id = tracking.id,
        description = tracking.description,
        numberOfHours = tracking.numberOfHours,
        Dificulty = tracking.Dificulty,
      };
  }
}
