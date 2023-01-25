namespace WeatherApp.Mobile;

public interface INavigationService
{
    Task NavigateToAsync(string destination);
}

public class ShellNavigationService : INavigationService
{
    public async Task NavigateToAsync(string destination)
    {
        await Shell.Current.GoToAsync(destination);
    }
}
