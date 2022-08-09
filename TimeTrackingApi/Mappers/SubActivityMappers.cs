using TimeTrackingApi.DTOs;

namespace TimeTrackingApi.Mappers;

public class SubActivityMappers {
  public static SubActivityDTO SubActivityToDTO(SubActivity subActivity) =>
            new SubActivityDTO
            {
                id = subActivity.id,
                description = subActivity.description,
                numberOfHours = subActivity.numberOfHours,
                Dificulty = subActivity.Dificulty
            };

  public static SubActivity DTOtoSubActivity(SubActivityDTO subActivityDTO) =>
      new SubActivity{
       id = subActivityDTO.id,
       description = subActivityDTO.description,
       numberOfHours = subActivityDTO.numberOfHours,
       Dificulty = subActivityDTO.Dificulty,
      };
  }
