public class TodoService : ITodoService
{
    private List<Todo> todos = new List<Todo>();

    public TodoService()
    {
        // Initialize with some sample data
        Add(new Todo(1, "Walk the dog", "Take the dog for a walk in the park", DateTime.Now.AddHours(1)));
        Add(new Todo(2, "Do the dishes", "Wash all the dirty dishes in the sink", DateTime.Now));
        Add(new Todo(3, "Do the laundry", "Wash and fold all the clothes", DateTime.Now.AddDays(1)));
        Add(new Todo(4, "Clean the bathroom", "Scrub the toilet, sink, and shower", DateTime.Now.AddDays(3)));
        Add(new Todo(5, "Clean the car", "Wash and vacuum the car", DateTime.Now.AddDays(2)));
    }

    public List<Todo> GetAll()
    {
        return todos;
    }

    public Todo GetById(int id)
    {
        return todos.FirstOrDefault(t => t.Id == id);
    }

    public void Add(Todo todo)
    {
        todos.Add(todo);
    }

    public void Update(Todo todo)
    {
        var existingTodo = todos.FirstOrDefault(t => t.Id == todo.Id);
        if (existingTodo != null)
        {
            todos[todos.IndexOf(existingTodo)] = todo;
        }
    }

    public void Delete(int id)
    {
        var todo = todos.FirstOrDefault(t => t.Id == id);
        if (todo != null)
        {
            todos.Remove(todo);
        }
    }
}