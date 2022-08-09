namespace TimeTrackingApi.DTOs;

public class TrackingDTO
{
  public long id { get; set; }
  public string? name { get; set; }
  public string? description { get; set; }
  public DateTime date { get; set; }
  public long numberOfHours { get; set; }

  public ICollection<SubActivityDTO>? subActivities { get; set; }

}