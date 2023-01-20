Feature: WeatherForecast


@mytag
Scenario: Temperature onload
	Given the forecast service returns a temp. of 75 C
	And a new view model
	When the page is loaded
	Then the temperature is 166 F

@mytag
Scenario Outline: Multiple Temperatures
	Given the forecast service returns a temp. of <tempC> C
	And a new view model
	When the page is loaded
	Then the temperature is <tempF> F

Examples: 
	| tempC | tempF |
	| 75    | 166   |
	| -40   | -39   |
	| 0     | 32    |
