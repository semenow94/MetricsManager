using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MetricsAgentTests
{
    public class RamControllerUnitTests
    {
        private RamMetricsController controller;

        public RamControllerUnitTests()
        {
            controller = new RamMetricsController();
        }

        [Fact]
        public void GetRamMetrics_ReturnsOk()
        {
            //Arrange
            var available = 1024;

            //Act
            var result = controller.GetRamMetrics(available);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}