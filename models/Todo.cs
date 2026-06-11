using System.Security.Cryptography;

public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public DateTime Date { get; set; }

    public Todo(int id, string title, string details, DateTime date)
    {
        Id = id;
        Title = title;
        Details = details;
        Date = date;
    }


}