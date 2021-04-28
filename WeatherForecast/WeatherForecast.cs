using System;

namespace WeatherForecast
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }
        public WeatherForecast(DateTime date, int temp)
        {
            Date = date;
            TemperatureC = temp;
        }
    }
}
