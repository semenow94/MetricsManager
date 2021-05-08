using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Model;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace MetricsAgentTests
{
    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController controller;
        private Mock<IHddMetricsRepository> mock;

        public HddMetricsControllerUnitTests()
        {
            mock = new Mock<IHddMetricsRepository>();

            controller = new HddMetricsController(mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит HddMetric объект
            mock.Setup(repository => repository.Create(It.IsAny<HddMetric>())).Verifiable();

            // выполняем действие на контроллере
            var result = controller.Create(new MetricsAgent.Requests.HddMetricCreateRequest { Time = DateTimeOffset.FromUnixTimeSeconds(2), Value = 50 });

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
            mock.Verify(repository => repository.Create(It.IsAny<HddMetric>()), Times.AtMostOnce());
        }
        [Fact]
        public void GetAll_ShouldCall_Create_From_Repository()
        {
            mock.Setup(repository => repository.GetAll()).Returns(new List<HddMetric>());

            var result = controller.GetAll();

            mock.Verify(repository => repository.GetAll());
        }

        [Fact]
        public void GetPeriod_ShouldCall_Create_From_Repository()
        {
            mock.Setup(repository => repository.GetPeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>())).Returns(new List<HddMetric>());

            var result = controller.GetPeriod(DateTimeOffset.Now, DateTimeOffset.Now);

            mock.Verify(repository => repository.GetPeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()));
        }
    }
}