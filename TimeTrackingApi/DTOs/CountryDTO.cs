namespace TimeTrackingApi.DTOs;

public class CountryDTO
{
  public long id { get; set; }
  public string? name { get; set; }
  public string? code { get; set; }

  public ICollection<TrackingDTO> Trackings { get; set; }

}