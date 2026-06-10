using System.Security.Cryptography;

public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public DateTime Date { get; set; }

    public Todo(string title, string details, DateTime date)
    {
        Id = RandomNumberGenerator.GetInt32(1, int.MaxValue);
        Title = title;
        Details = details;
        Date = date;
    }


}