using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast
{
    public class ValuesHolder
    {
        public List<WeatherForecast> Values = new List<WeatherForecast>();
        public string requestStatus;
        public void Add(DateTime date, int temp)
        {
            var obj = SeekElement(date);
            if(obj==null)
            {
                Values.Add(new WeatherForecast(date, temp));
                requestStatus = "Успешно добавлено";
                return;
            }
            requestStatus = "Элемент уже был добавлен";
        }
        public void Update(DateTime date, int temp)
        {
            var obj = SeekElement(date);
            if (obj != null)
            {
                obj.TemperatureC = temp;
                requestStatus = "Успешно изменено";
                return;
            }
            requestStatus = "Элемент отсутствует";
        }
        public void Delete(DateTime date)
        {
            var obj = SeekElement(date);
            if (obj != null)
            {
                Values.Remove(obj);
                requestStatus = "Успешно Удалено";
                return;
            }
            requestStatus = "Элемент отсутствует";
        }
        WeatherForecast SeekElement(DateTime date)
        {
            foreach (WeatherForecast obj in Values)
            {
                if (obj.Date == date)
                {
                    return obj;
                }
            }
            return null;
        }
    }
}
