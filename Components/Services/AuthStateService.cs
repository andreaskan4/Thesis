using Thesis.Models;
using Microsoft.JSInterop;
using System.Text.Json;

namespace Thesis.Services;

public class AuthStateService
{
    private readonly IJSRuntime _jsRuntime;
    private User? _currentUser;
    private bool _initialized = false;

    public AuthStateService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public User? CurrentUser
    {
        get => _currentUser;
        private set
        {
            _currentUser = value;
            NotifyStateChanged();
        }
    }

    public bool IsLoggedIn => CurrentUser != null;

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();

    public async Task InitializeAsync()
    {
        if (!_initialized)
        {
            await LoadUserFromStorage();
            _initialized = true;
        }
    }

    public async Task LoginAsync(User user)
    {
        CurrentUser = user;
        await SaveUserToStorage(user);
    }

    public async Task LogoutAsync()
    {
        CurrentUser = null;
        await ClearUserFromStorage();
        NotifyStateChanged();
    }

    private async Task SaveUserToStorage(User user)
    {
        try
        {
            var userJson = JsonSerializer.Serialize(user);
            await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", userJson);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving user to storage: {ex.Message}");
        }
    }

    private async Task LoadUserFromStorage()
    {
        try
        {
            var userJson = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
            if (!string.IsNullOrEmpty(userJson))
            {
                var user = JsonSerializer.Deserialize<User>(userJson);
                CurrentUser = user;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading user from storage: {ex.Message}");
        }
    }

    private async Task ClearUserFromStorage()
    {
        try
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", "currentUser");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error clearing user from storage: {ex.Message}");
        }
    }
}