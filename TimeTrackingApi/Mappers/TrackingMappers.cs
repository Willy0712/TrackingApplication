using TimeTrackingApi.DTOs;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.Mappers;


public static class TrackingMappers
{




  public static TrackingDTO trackinToDTO(tracking tracking) =>
            new TrackingDTO
            {
              id = tracking.id,
              name = tracking.name,
              description = tracking.description,
              date = tracking.date,
              numberOfHours = tracking.numberOfHours,
              subActivities = tracking.SubActivities?.Select(sa => SubActivityMappers.SubActivityToDTO(sa)).ToList(),
              // parent = long.Parse(tracking.Parent.id.ToString())



            };

  public static tracking DTOtoTracking(TrackingDTO trackingDTO) =>
  new tracking
  {

    id = trackingDTO.id,
    name = trackingDTO.name,
    description = trackingDTO.description,
    date = trackingDTO.date,
    numberOfHours = trackingDTO.numberOfHours,
    SubActivities = trackingDTO.subActivities?.Select(subActivityDto => SubActivityMappers.DTOtoSubActivity(subActivityDto)).ToList(),

    // Parent = _context.Users.Find(trackingDTO.parent)
  };



}



