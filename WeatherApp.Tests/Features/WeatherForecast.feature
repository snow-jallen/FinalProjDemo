@mytag
Feature: WeatherForecast


Scenario: Temperature onload
	Given the forecast service returns a temp. of 75 C
	And a new view model
	When the page is loaded
	Then the temperature is 166 F

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


Scenario Outline: Specific Date
	Given a forecast service returns the following forecasts
	| Date       | TemperatureC |
	| 2023-01-20 | 0            |
	| 2023-01-21 | 75           |
	| 2023-01-22 | -40          |
	And a new view model
	When user inputs <Date>
	Then the temperature is <tempF> F
Examples: 
	| Date       | tempF |
	| 2023-01-20 | 32    |
	| 2023-01-21 | 166   |
	| 2023-01-22 | -39   |