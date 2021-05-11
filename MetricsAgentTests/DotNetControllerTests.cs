using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Model;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace MetricsAgentTests
{
    public class DotNetMetricsControllerUnitTests
    {
        private DotNetMetricsController controller;
        private Mock<IDotNetMetricsRepository> mock;

        public DotNetMetricsControllerUnitTests()
        {
            mock = new Mock<IDotNetMetricsRepository>();

            controller = new DotNetMetricsController(mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит DotNetMetric объект
            mock.Setup(repository => repository.Create(It.IsAny<DotNetMetric>())).Verifiable();

            // выполняем действие на контроллере
            var result = controller.Create(new MetricsAgent.Requests.DotNetMetricCreateRequest { Time = DateTimeOffset.FromUnixTimeSeconds(2), Value = 50 });

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
            mock.Verify(repository => repository.Create(It.IsAny<DotNetMetric>()), Times.AtMostOnce());
        }
        [Fact]
        public void GetAll_ShouldCall_Create_From_Repository()
        {
            mock.Setup(repository => repository.GetAll()).Returns(new List<DotNetMetric>());

            var result = controller.GetAll();

            mock.Verify(repository => repository.GetAll());
        }

        [Fact]
        public void GetPeriod_ShouldCall_Create_From_Repository()
        {
            mock.Setup(repository => repository.GetPeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>())).Returns(new List<DotNetMetric>());

            var result = controller.GetPeriod(DateTimeOffset.Now, DateTimeOffset.Now);

            mock.Verify(repository => repository.GetPeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()));
        }
    }
}