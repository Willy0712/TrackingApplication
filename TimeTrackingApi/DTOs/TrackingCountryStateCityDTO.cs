namespace TimeTrackingApi.DTOs;

public class TrackingCountryStateCityDTO
{
  public long userId { get; set; }
  public string? name { get; set; }
  public string? description { get; set; }
  public DateTime date { get; set; }
  public long numberOfHours { get; set; }

  public string CityName { get; set; }



}