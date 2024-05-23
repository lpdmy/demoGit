namespace TeachMate.Domain;
public class LearningSession
{
    public int Slot { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}
