using TimeTrackingApi;

public class SubActivity{
    public long id { get; set; }
    
    public string? description { get; set; }
    
    public long numberOfHours { get; set; }

    public string? Dificulty { get; set; }

    public tracking? Parent { get; set; }

    
}