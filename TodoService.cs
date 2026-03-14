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

}