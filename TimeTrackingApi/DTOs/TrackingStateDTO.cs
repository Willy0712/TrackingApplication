namespace TimeTrackingApi.DTOs;

public class TrackingStateDTO
{
  public long userId { get; set; }
  public string? name { get; set; }
  public string? description { get; set; }
  public DateTime date { get; set; }
  public long numberOfHours { get; set; }

  // public ICollection<SubActivityDTO>? subActivities { get; set; }

  // public long CountryID { get; set; }

  public string StateName { get; set; }

}