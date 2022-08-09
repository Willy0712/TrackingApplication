using TimeTrackingApi.DTOs;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.Mappers;


public static class StateMappers
{




  public static StateDTO stateToDTO(State state) =>
            new StateDTO
            {
              id = state.id,
              name = state.name,
              code = state.code,
              Country = state.Country
            };

  public static State DTOtoState(StateDTO stateDTO) =>
  new State
  {

    id = stateDTO.id,
    name = stateDTO.name,
    code = stateDTO.code,
    Country = stateDTO.Country
  };

}



