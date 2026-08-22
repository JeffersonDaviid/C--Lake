

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public ActionResult<List<Todo>> GetAll()
    {
        return _todoService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Todo> GetById(int id)
    {
        var todo = _todoService.GetById(id);
        if (todo == null)
        {
            return NotFound();
        }
        return todo;
    }

    [HttpPost]
    public ActionResult Add(Todo todo)
    {
        _todoService.Add(todo);
        return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, Todo todo)
    {
        if (id != todo.Id)
        {
            return BadRequest();
        }
        var existingTodo = _todoService.GetById(id);
        if (existingTodo == null)
        {
            return NotFound();
        }
        _todoService.Update(todo);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var existingTodo = _todoService.GetById(id);
        if (existingTodo == null)
        {
            return NotFound();
        }
        _todoService.Delete(id);
        return NoContent();
    }
}