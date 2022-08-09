namespace TimeTrackingApi;

public class Country
{
  public long id { get; set; }
  public string? name { get; set; }
  public string? code { get; set; }

  public ICollection<tracking> Trackings { get; set; }

}