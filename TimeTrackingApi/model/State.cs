namespace TimeTrackingApi;

public class State
{
  public long id { get; set; }
  public Country? Country { get; set; }
  public string? name { get; set; }
  public string? code { get; set; }

  public ICollection<tracking> Trackings { get; set; }

}