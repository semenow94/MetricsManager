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
        public ValuesHolder()
        {
            Random random = new Random();
            DateTime date = DateTime.Now;
            for(int i=0; i<10;i++)
            {
                date = date.AddDays(1);
                Add(date, random.Next(0, 20));
            }
        }
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
        public void DeleteRange(DateTime start, DateTime end)
        {
            int count = Values.Count;
            int deleted = 0;
            for(int i=0;i<count;i++)
            {
                if(Values[i].Date>=start && Values[i].Date <= end)
                {
                    Values.RemoveAt(i);
                    i--;
                    count--;
                    deleted++;
                }
            }
            requestStatus = $"Успешно удалено {deleted} элементов ";
        }
        public List<WeatherForecast> ReadRange(DateTime start, DateTime end)
        {
            List<WeatherForecast> list = new List<WeatherForecast>();
            foreach (WeatherForecast obj in Values)
            {
                if (obj.Date >= start && obj.Date <= end)
                {
                    list.Add(obj);
                }
            }
            return list;
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
