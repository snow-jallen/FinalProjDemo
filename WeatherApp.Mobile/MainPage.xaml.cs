using WeatherApp.Mobile.ViewModels;

namespace WeatherApp.Mobile
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}