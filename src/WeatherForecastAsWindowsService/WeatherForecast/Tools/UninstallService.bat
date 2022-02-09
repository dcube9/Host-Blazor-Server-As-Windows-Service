@echo off
Set RunNssm="%~dp0nssm.exe"

%RunNssm% stop BlazorWeatherForecastService
%RunNssm% remove BlazorWeatherForecastService confirm

netsh http delete urlacl url=http://+:5555/
netsh advfirewall firewall delete rule name="Blazor WeatherForecast Service"
pause