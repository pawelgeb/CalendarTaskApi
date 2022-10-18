namespace CalendarTaskApi.Models
{
    public class CalendarTask
    {
        public int Id { get; set; }
        public string? Task { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
        public Priority Priority { get; set; }

    }
    public enum Priority
    {
        Low = 1,
        Medium = 2,
        High = 3
    }
}
