using TimeTrackingApi.DTOs;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.Mappers;


public static class CountryMappers
{




  public static CountryDTO countryToDTO(Country country) =>
            new CountryDTO
            {
              id = country.id,
              name = country.name,
              code = country.code,
              // subActivities = tracking.SubActivities?.Select(sa => SubActivityMappers.SubActivityToDTO(sa)).ToList(),

              Trackings = country.Trackings?.Select(data => TrackingMappers.trackinToDTO(data)).ToList(),

            };

  public static Country DTOtoCountry(CountryDTO countryDTO) =>
  new Country
  {

    id = countryDTO.id,
    name = countryDTO.name,
    code = countryDTO.code,
    // Trackings = countryDTO.Trackings.ToList()
    // SubActivities = trackingDTO.subActivities?.Select(subActivityDto => SubActivityMappers.DTOtoSubActivity(subActivityDto)).ToList(),
    Trackings = countryDTO.Trackings?.Select(countryDTO => TrackingMappers.DTOtoTracking(countryDTO)).ToList()
  };

}



