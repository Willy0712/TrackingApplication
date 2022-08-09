namespace TimeTrackingApi.DTOs;

public class CityDTO
{
  public long id { get; set; }
  public State? State { get; set; }
  public string? name { get; set; }
  public string? code { get; set; }

  public ICollection<TrackingDTO> Trackings { get; set; }

}