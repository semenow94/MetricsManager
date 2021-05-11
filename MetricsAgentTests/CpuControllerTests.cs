using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Model;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace MetricsAgentTests
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController controller;
        private Mock<ICpuMetricsRepository> mock;

        public CpuMetricsControllerUnitTests()
        {
            mock = new Mock<ICpuMetricsRepository>();

            controller = new CpuMetricsController(mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // ������������� �������� ��������
            // � �������� ����������� ��� � ����������� �������� CpuMetric ������
            mock.Setup(repository => repository.Create(It.IsAny<CpuMetric>())).Verifiable();

            // ��������� �������� �� �����������
            var result = controller.Create(new MetricsAgent.Requests.CpuMetricCreateRequest { Time = DateTimeOffset.FromUnixTimeSeconds(2), Value = 50 });

            // ��������� �������� �� ��, ��� ���� ������� ����������
            // ������������� �������� ����� Create ����������� � ������ ����� ������� � ���������
            mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetAll_ShouldCall_Create_From_Repository()
        {
            mock.Setup(repository => repository.GetAll()).Returns(new List<CpuMetric>());

            var result = controller.GetAll();

            mock.Verify(repository => repository.GetAll());
        }

        [Fact]
        public void GetPeriod_ShouldCall_Create_From_Repository()
        {
            mock.Setup(repository => repository.GetPeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>())).Returns(new List<CpuMetric>());

            var result = controller.GetPeriod(DateTimeOffset.Now, DateTimeOffset.Now);

            mock.Verify(repository => repository.GetPeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()));
        }
    }
}