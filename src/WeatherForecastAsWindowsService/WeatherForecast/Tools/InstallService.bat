@echo off
Set RunNssm="%~dp0nssm.exe"

%RunNssm% install BlazorWeatherForecastService "%~dp0WeatherForecast.exe"
%RunNssm% set BlazorWeatherForecastService Start SERVICE_DEMAND_START

netsh http add urlacl url=http://+:5555/ user=everyone
netsh advfirewall firewall add rule name="Blazor WeatherForecast Service" dir=in action=allow protocol=TCP localport=5555
pause