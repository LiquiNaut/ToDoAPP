using Blazored.LocalStorage;
using ToDoApp.Models;

namespace ToDoApp.Services;

public class TodoService
{
    public readonly ILocalStorageService _LocalStorageService;
    public const string StorageKey = "todos";

    public TodoService(ILocalStorageService localStorageService)
    {
        _LocalStorageService = localStorageService;
    }

    public async Task SaveTodoList(List<TodoItem> todos)
    {
        await _LocalStorageService.SetItemAsync(StorageKey, todos);
    }

    public async Task<List<TodoItem>> GetTodoItems()
    {
        return await _LocalStorageService.GetItemAsync<List<TodoItem>>(StorageKey) ?? new List<TodoItem>();
    }
}