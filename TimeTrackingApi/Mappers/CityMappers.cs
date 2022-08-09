using TimeTrackingApi.DTOs;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.Mappers;


public static class CityMappers
{




  public static CityDTO ctiyToDTO(City city) =>
            new CityDTO
            {
              id = city.id,
              name = city.name,
              code = city.code,
              State = city.State
            };

  public static City DTOtoCity(CityDTO cityDTO) =>
  new City
  {

    id = cityDTO.id,
    name = cityDTO.name,
    code = cityDTO.code,
    State = cityDTO.State
  };
};




