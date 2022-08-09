namespace TimeTrackingApi.DTOs;

public class StateDTO
{
  public long id { get; set; }
  public Country? Country { get; set; }
  public string? name { get; set; }
  public string? code { get; set; }
  public ICollection<TrackingDTO> Trackings { get; set; }

}