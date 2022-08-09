namespace TimeTrackingApi;

public class User 
{
  public long id { get; set; }

  public string? FirstName { get; set; }
  public string? LastName { get; set; }

  public string? UserName { get; set; }

  public string Email { get; set; }

  public string Password { get; set; }

  public int IsConfirmed { get; set; }

  public DateTime? CreatedDate { get; set; }

  public ICollection<tracking>? Trackings { get; set; }


}