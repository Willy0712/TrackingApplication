namespace TimeTrackingApi;

public class City
{
  public long id { get; set; }
  public State? State { get; set; }
  public string? name { get; set; }
  public string? code { get; set; }

  public ICollection<tracking> Trackings { get; set; }


}