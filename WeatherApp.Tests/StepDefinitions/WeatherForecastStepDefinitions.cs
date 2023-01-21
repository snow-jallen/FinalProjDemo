using Moq;
using Shared.Data;
using System;
using TechTalk.SpecFlow;
using WeatherApp.Mobile.ViewModels;
using TechTalk.SpecFlow.Assist;

namespace WeatherApp.Tests.StepDefinitions
{
    [Binding]
    public class WeatherForecastStepDefinitions
    {
        private readonly ScenarioContext _context;

        public WeatherForecastStepDefinitions(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"the forecast service returns a temp\. of (.*) C")]
        public void GivenTheForecastServiceReturnsATemp_Of(int temperature)
        {
            var mockWeather = new[] {
                new WeatherForecast()
                {
                    TemperatureC = temperature
                }
            };
            var mock = new Mock<IWeatherForecastService>();
            mock.Setup(x => x.GetForecastAsync(It.IsAny<DateTime>())).ReturnsAsync(mockWeather);
            _context.Set(mock.Object);
            
        }

        [Given(@"a new view model")]
        public void GivenANewViewModel()
        {
            var vm = new MainViewModel(_context.Get<IWeatherForecastService>());
            _context.Set(vm);
        }

        [When(@"the page is loaded")]
        public void WhenThePageIsLoaded()
        {
            var vm = _context.Get<MainViewModel>();
            vm.LoadedCommand.Execute(null);
        }

        [Then(@"the temperature is (.*) F")]
        public void ThenTheTemperatureIs(double temp)
        {
            var vm = _context.Get<MainViewModel>();
            vm.Temperature.Should().Be(temp);
        }

        [Given(@"a forecast service returns the following forecasts")]
        public void GivenAForecastServiceReturnsTheFollowingForecasts(Table table)
        {
            var forecasts = table.CreateSet<WeatherForecast>();
            var mock = new Mock<IWeatherForecastService>();
            foreach (var forecast in forecasts)
            {
                mock.Setup(x => x.GetForecastAsync(forecast.Date)).ReturnsAsync(forecasts.ToArray());
            }
            _context.Set(mock.Object);
        }

        [When(@"user inputs (.*)")]
        public void WhenUserInputs(DateTime date)
        {
            var vm = _context.Get<MainViewModel>();
            vm.SelectedDate = date;
        }

    }
}
