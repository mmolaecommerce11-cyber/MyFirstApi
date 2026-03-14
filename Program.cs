var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var myTodos = new List<TodoItem>();
myTodos.Add(new TodoItem { Id = 1, Title = "Go and Buy Milk", IsComplete = true });
myTodos.Add(new TodoItem { Id = 2, Title = "Clean The House", IsComplete = false });
myTodos.Add(new TodoItem { Id = 3, Title = "Learn Coding With Claude", IsComplete = true });

app.MapGet("/myTodos", () => { return myTodos; });

app.MapPost("/myTodos", (TodoItem newTodo) => {
    if (string.IsNullOrEmpty(newTodo.Title)) // If the todo that was just created has an empty title, We will  return a 400 bad request message.
    {
        return Results.BadRequest("Go hlokega Title/ Title is required");
    }// I have added this validation first to ensure that we do not add an item with an empty title to our list.
    myTodos.Add(newTodo);//Now we add aftere the validation.

    return Results.Ok(newTodo);
});


//Update existing TodoItem

app.MapPut("/myTodos/{id}", (int id) =>
{
    var todo = myTodos.FirstOrDefault(t => t.Id == id);
    if (todo is null)
    {
        return Results.NotFound();
    }
    todo.IsComplete = !todo.IsComplete;
    return Results.Ok(todo);
});


app.Run();

public class TodoItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool IsComplete { get; set; }
}