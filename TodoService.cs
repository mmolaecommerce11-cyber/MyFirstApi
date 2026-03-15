using Microsoft.AspNetCore.Http.HttpResults;

public class TodoService
{
    private List<TodoItem> _todos = new List<TodoItem>();


    //Get All TodoItems
    public List<TodoItem> GetAll(TodoItem todos)
    {
        return _todos;
    }

    //Create a new TodoItem

    public bool Add(TodoItem newTodo)
    {
        if (string.IsNullOrEmpty(newTodo.Title))
        {
            return false;
        }

        _todos.Add(newTodo);
        return true;
    }

    //Toggle Complete Status of a TodoItem by Id
    public bool ToggleComplete(int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id); // we use this method to find the item by id
        if (todo == null)
        {
            return false;
        }
        todo.IsComplete = !todo.IsComplete;
        return true;
    }

}