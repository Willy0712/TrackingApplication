namespace TimeTrackingApi
{
  public class tracking
  {

    public long id { get; set; }
    public string? name { get; set; }
    public string? description { get; set; }
    public DateTime date { get; set; }
    public long numberOfHours { get; set; }

    public long? Countryid { get; set; }
    public Country? Country { get; set; }

    public long? Cityid { get; set; }
    public City? City { get; set; }

    public long? Stateid { get; set; }
    public State? State { get; set; }

    public ICollection<SubActivity>? SubActivities { get; set; }

    public User? Parent { get; set; }
  }
}